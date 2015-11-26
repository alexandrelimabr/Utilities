using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandre.AssemblyReader
{ /// <summary>
  /// Small code that read all the assembliesand .dlls (non-managed) in a given folder and creates 
  /// 4 text files with information on the .dll and assemblies.
  /// 1) List of all .net assemblies with CodeBase information
  /// 2) A .bat to register all .net assemblies to GAC
  /// 3) A .bat to un-register all .net assemblies from GAC
  /// 4) A list of all .dll that are managed.
  /// 
  /// POSSIBLE USES
  /// -------------
  /// Use cases where this program can be used:
  /// - Analyze quickly what libraries are managed or not inside a folder
  /// - Register/remove quickly all libraries in GAC
  /// - Prepare the "codebase" configuration needed to add in the app.config file (when sharing a folder with shared libraries)
  /// 
  /// TESTING:
  /// ----------------
  /// Program needs a folder with .dlls to be passed as argument.
  /// 
  /// IMPROVEMENTS
  /// ------------
  ///Adding more command line arguments and their related logic and user explanation can de done. 
  ///
  /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            /*
                    <codeBase version="1.0.0.0" 
                         href= "file:///c:\ MyTest\ProductCabinet ReferencedFile.dll"/>

               */
            string folderName = string.Empty;

            List<AssemblyInfo> assemblyInfoList = new List<AssemblyInfo>();
            StringBuilder nonManagedFileList = new StringBuilder();

            if (args.Length > 0)
            {
                folderName = args[0];
            }
            else
            {
                folderName = AppDomain.CurrentDomain.BaseDirectory;
            }

            Console.WriteLine("Reading files from: {0}", folderName);

            string[] fileList = Directory.GetFiles(folderName);



            foreach (var file in fileList)
            {

                if (Path.GetExtension(file) == ".dll")
                {
                    AssemblyInfo assemblyInfo = GetAssemblyInfo(file);
                    if (assemblyInfo != null)
                    {
                        assemblyInfoList.Add(assemblyInfo);
                    }
                    else
                    {
                        nonManagedFileList.AppendLine(file);
                    }
                }
            }

            StringBuilder sb = new StringBuilder();
            StringBuilder sbGac = new StringBuilder();
            StringBuilder sbGacRemove = new StringBuilder();


            sbGac.AppendLine("C:");
            sbGac.AppendLine("cd \"C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.0A\\Bin\\NETFX 4.0 Tools\"");

            sbGacRemove.AppendLine("C:");
            sbGacRemove.AppendLine("cd \"C:\\Program Files (x86)\\Microsoft SDKs\\Windows\\v7.0A\\Bin\\NETFX 4.0 Tools\"");

            foreach (var info in assemblyInfoList)
            {
                #region Sample CodeBase Config
                /*
               <configuration>
               <runtime>
                  <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
                     <dependentAssembly>
                        <assemblyIdentity name="myAssembly"
                                          publicKeyToken="32ab4ba45e0a69a1"
                                          culture="neutral" />
                        <codeBase version="2.0.0.0"
                                  href="http://www.litwareinc.com/myAssembly.dll"/>
                     </dependentAssembly>
                  </assemblyBinding>
               </runtime>
            </configuration>

            */
                #endregion

                string result = String.Format("<dependentAssembly><assemblyIdentity name=\"{0}\" publicKeyToken=\"{1}\" culture=\"{2}\" /><codeBase version=\"{3}\" href=\"file:///{4}/{5}.dll\" /></dependentAssembly>"
                    , info.AssemblyName
                    , info.PublicKeyToken
                    , info.Culture
                    , info.AssemblyVersion
                    , info.AssemblyPath.Replace('\\', '/')
                    , info.AssemblyName);

                info.Culture = info.Culture;

                info.PublicKeyToken = info.PublicKeyToken;

                sb.AppendLine(result);

                sbGac.AppendLine(string.Format("gacutil -i \"{0}/{1}.dll\"", info.AssemblyPath, info.AssemblyName));
                sbGacRemove.AppendLine(string.Format("gacutil -u \"{0}\"", info.AssemblyName));


                // gacutil /u "hello,Version=1.0.0.0, Culture=neutral, PublicKeyToken=0123456789ABCDEF"
            }
            sbGac.AppendLine("PAUSE");
            sbGacRemove.AppendLine("PAUSE");

            string outputFileName = "AssemblyList.txt";
            string outputNonManagedFileList = "NonManagedFileList.txt";
            string gacUtilCommandFile = "GacUtilCommandfile.bat";
            string gacUtilCommandFileRemove = "GacUtilCommandfileRemove.bat";



            File.WriteAllText(outputFileName, sb.ToString());
            File.WriteAllText(outputNonManagedFileList, nonManagedFileList.ToString());
            File.WriteAllText(gacUtilCommandFile, sbGac.ToString());
            File.WriteAllText(gacUtilCommandFileRemove, sbGacRemove.ToString());

            Console.WriteLine("Assmbly List formated as codebase was printed on {0}!", outputFileName);



        }

        private static AssemblyInfo GetAssemblyInfo(string fileName)
        {
            AssemblyInfo result = null;

            try
            {
                System.Reflection.AssemblyName testAssembly =
                    System.Reflection.AssemblyName.GetAssemblyName(fileName);

                result = new AssemblyInfo(testAssembly.Name, testAssembly.Version.ToString(), Path.GetDirectoryName(fileName));

                if (testAssembly.CultureName == string.Empty)
                {
                    result.Culture = "neutral";
                }
                else
                {
                    result.Culture = testAssembly.CultureName;
                }

                result.FullName = testAssembly.FullName;

                result.PublicKeyToken = GetAssemblyPublickKeyToken(testAssembly.GetPublicKeyToken());

                Debug.WriteLine("File {0} was found and it is an assembly.", fileName);
            }

            catch (System.IO.FileNotFoundException)
            {
                Debug.WriteLine("The file {0} cannot be found.", fileName);
            }

            catch (System.BadImageFormatException)
            {
                Debug.WriteLine("The file {0} is not an assembly.", fileName);
            }

            catch (System.IO.FileLoadException)
            {
                Debug.WriteLine("The assembly {0} has already been loaded.", fileName);
            }

            return result;

        }

        public static string GetAssemblyPublickKeyToken(byte[] token)
        {

            if (token == null || token.Length == 0)
                return null;

            return token.Select(x => x.ToString("x2")).Aggregate((x, y) => x + y);
        }


        private class AssemblyInfo
        {
            public string AssemblyName { get; set; }

            public string FullName { get; set; }
            public string AssemblyVersion { get; set; }
            public string AssemblyPath { get; set; }

            public string Culture { get; set; }

            public string PublicKeyToken { get; set; }

            public AssemblyInfo(string assemblyName, string assemblyVersion, string assemblyPath)
            {
                AssemblyName = assemblyName;
                AssemblyVersion = assemblyVersion;
                AssemblyPath = assemblyPath;
            }
        }
    }
}
