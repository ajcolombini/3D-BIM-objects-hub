using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Web;

namespace Framework.Util
{
    /// <summary>
    /// Class File Manipulation
    /// </summary>
    public class clsFileUtil
    {
        /// <summary>
        /// ReadsFilesDirectory - Reads in the specified files. Returns a list of files in the directory.
        /// </summary>
        /// <param name="filesPath">Path the of directory.</param>
        /// <param name="fileExtencion">File extension is not mandatory. Is passed as 'null' is returned all the files directory.</param>
        /// <returns></returns>
        public static FileInfo[] ReadsFilesDirectory(string filesPath, string fileExtension)
        {
            FileInfo[] _fi;
            try
            {
                if (string.IsNullOrEmpty(fileExtension))
                {
                    DirectoryInfo _dir = new DirectoryInfo(filesPath);
                    _fi = _dir.GetFiles();
                }
                else
                {
                    DirectoryInfo _dir = new DirectoryInfo(filesPath);
                    _fi = _dir.GetFiles("*." + fileExtension);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsFileUtil.ReadsFilesDirectory >> " + ex.Message);
            }
            return _fi;
        }

        /// <summary>
        /// DeleteFile. Deletes file specified folder.
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="sourcePath">Source Path</param>
        /// <returns></returns>
        public static bool DeleteFile(string fileName, string sourcePath)
        {
            bool _ret = false;
            try
            {
                if (Directory.Exists(sourcePath))
                {
                    File.Delete(Path.Combine(sourcePath, fileName));
                    _ret = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsFileUtil.DeleteFile >> " + ex.Message);
            }
            return _ret;
        }

        /// <summary>
        /// DeleteFile. Deletes file specified folder.
        /// </summary>
        /// <param name="listFileName">list with the names of files to be deleted</param>
        /// <param name="sourcePath">Source Path</param>
        /// <returns></returns>
        public static bool DeleteFile(List<string> listFileName, string sourcePath)
        {
            bool _ret = false;
            try
            {
                if (Directory.Exists(sourcePath))
                {
                    if (listFileName.Count > 0)
                    {
                        foreach (var _aq in listFileName)
                        {
                            DeleteFile(_aq.ToString(), sourcePath);
                            _ret = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsFileUtil.DeleteFile (overloaded) >> " + ex.Message);
            }
            return _ret;
        }

        /// <summary>
        /// Copy files to specified folder (Do not delete)
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="targetPath">Destination Path</param>
        /// <param name="sourcePath">Source Path</param>
        public static void CopyFiles(string fileName, string targetPath, string sourcePath)
        {
            try
            {
                if (Directory.Exists(targetPath) && Directory.Exists(sourcePath))
                {
                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = Path.Combine(sourcePath, fileName);
                    string destFile = Path.Combine(targetPath, fileName);
                    // To copy a file to another location and 
                    // overwrite the destination file if it already exists.
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsFileUtil.CopyFiles >> " + ex.Message);
            }
        }


        /// <summary>
        /// MoveFiles - Copy files to specified folder and delete from original folder
        /// If the file already exists on target folder, append a numeric sequencial number to it.
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="targetPath">Destination Path</param>
        /// <param name="sourcePath">Source Path</param>
        public static void MoveFiles(string fileName, string targetPath, string sourcePath)
        {
            try
            {
                if (Directory.Exists(targetPath) && Directory.Exists(sourcePath))
                {
                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = Path.Combine(sourcePath, fileName);
                    string newFile = GetUniqueName(fileName, targetPath);
                    string destFile = Path.Combine(targetPath, newFile);
                    
                    File.Copy(sourceFile, destFile, true);
                    File.Delete(sourceFile);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsFileUtil.MoveFiles >> " + ex.Message);
            }
        }


        /// <summary>
        /// MoveFiles [OVERLOADED] - Moves files to 'targetPath' (Exclude from 'sourcePath')
        /// </summary>
        /// <param name="fileName">File Name</param>
        /// <param name="targetPath">Destination Path</param>
        /// <param name="sourcePath">Source Path</param>
        public static void MoveFilesX(string fileName, string targetPath, string sourcePath)
        {
            try
            {
                if (Directory.Exists(targetPath) && Directory.Exists(sourcePath))
                {
                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    // To copy a file to another location and 
                    // overwrite the destination file if it already exists.
                    File.Copy(sourceFile, destFile, true);
                    File.Delete(sourceFile);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Renames a file and moves it to another directory
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void RenameFile(string fileName, string newFileName, string sourcePath, string targetPath)
        {
            try
            {
                if (Directory.Exists(sourcePath) && Directory.Exists(targetPath))
                {
                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = Path.Combine(sourcePath, fileName);
                    string destFile = Path.Combine(targetPath, newFileName);
                    
                    File.Move(sourceFile, destFile);
                }
            }
            catch (Exception ex) {
                throw new Exception("clsFileUtil.RenameFile >> " + ex.Message);
            }
        }

        /// <summary>
        /// Renames a file on the same directory
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newFileName"></param>
        /// <param name="sourcePath"></param>
        public static void RenameFile(string fileName, string newFileName, string sourcePath)
        {
            try
            {
                if (Directory.Exists(sourcePath) )
                {
                    // Use Path class to manipulate file and directory paths.
                    string sourceFile = Path.Combine(sourcePath, fileName);
                    string destFile = Path.Combine(sourcePath, newFileName);

                    File.Move(sourceFile, destFile);
                }
            }
            catch (Exception ex) {
                throw new Exception("clsFileUtil.RenameFile (overloaded) >> " + ex.Message);
            }
        }




        public static bool RecordTxtFile(StringBuilder sb, string pathSaveFile, string fileName) {
            bool _ret = false;

            try {

                using (FileStream fs = File.Create(pathSaveFile + "\\" + fileName + ".txt"))
                {
                    using(StreamWriter sw = new StreamWriter(fs)){
                        //Método Write para escrever em nosso arquivo texto
                        sw.Write(sb.ToString());
                        _ret = true;
                    }
                }
            }            
            catch (Exception ex) {
                throw new Exception("clsFileUtil.RecordTxtFile >> " + ex.Message);
            }
            return _ret;        
        }


        /// <summary>
        /// Metódo não coloca extensão no arquivo. Caso venha extensão, irá assumir o que vier no fileName.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="pathToSaveFile"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool RecordFile(StringBuilder sb, string pathToSaveFile, string fileName)
        {
            bool _ret = false;

            try
            {

                if (!Directory.Exists(pathToSaveFile))
                    Directory.CreateDirectory(pathToSaveFile);

                using (FileStream fs = File.Create(pathToSaveFile + "\\" + fileName))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        //Método Write para escrever em nosso arquivo texto
                        sw.Write(sb.ToString());
                        _ret = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("clsFileUtil.RecordFile >> " + ex.Message);
            }
            return _ret;
        }


        /// <summary>
        /// Retorna um nome único para determinado arquivo na pasta informada.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="folderPath"></param>
        /// <example>Se já houver um "test.txt" na pasta "C:/", retorna test(1).txt</example>
        /// <returns>Nome único</returns>
        public static string GetUniqueName(string name, string folderPath)
        {
            string validatedName = name;
            int tries = 1;

            string _nameWithoutExt = Path.GetFileNameWithoutExtension(name);
            string _extension = Path.GetExtension(name);

            while (File.Exists(Path.Combine(folderPath, validatedName)))
            {
                validatedName = string.Format("{0}({1})", _nameWithoutExt, tries++);
                validatedName += _extension;
            }
            return validatedName;
        }

        /// <summary>
        /// DownloadFile - Para Arquivos Web
        /// </summary>
        /// <param name="Arquivo">string com caminho do arquivo.</param>
        public static void DownloadFileForWeb(string Arquivo)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Charset = "iso-8859-1";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            HttpContext.Current.Response.HeaderEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
            HttpContext.Current.Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(Arquivo.Replace(" ", "")));
            HttpContext.Current.Response.ContentType = "application/octet-stream";


            if (File.Exists(Arquivo))
            {
                HttpContext.Current.Response.WriteFile(Arquivo);
                HttpContext.Current.Response.End();
            }

        }
    }
}
