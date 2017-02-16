/* 
 * ========================================================================
 * Copyright(c) 2015-2016 上海诺诚电气有限公司, All Rights Reserved.
 * ========================================================================
 * 描述信息(Description): 
 *  
 * 创建作者(Create Author):张超(Angle)
 * 创建时间(Create Datetime)：2017/2/13 13:40:55 
 * 文件名(File Name)：OperateFile 
 * 
 * 修改记录(Update Record):
 *  R1.
 *      修改作者(Update Author):           
 *      修改时间(Update Datetime):               
 *      修改说明(Update Description): 
 * ======================================================================== 
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AutoUpdate.Core.Data;
using AutoUpdate.ICore.IService;
using AutoUpdate.Tools;

namespace AutoUpdate.Core.Service
{
    public class OperateFile : IOperateFile
    {
        private string filePath = string.Empty;//文件更新路径

        public OperateFile()
        {
        }

        public OperateFile(string filePath)
        {
            this.filePath = filePath;
        }

        public DownloadFileResult DownloadFile(DownloadFileInfo downFileInfo)
        {
            string path = string.Empty;

            if (!string.IsNullOrEmpty(this.filePath))
            {
                path = string.IsNullOrEmpty(downFileInfo.PhysicalPath) ? this.filePath + downFileInfo.RelativePath : downFileInfo.PhysicalPath + "\\" + downFileInfo.FileName;
            }
            else
            {
                path = downFileInfo.PhysicalPath;
            }

            return this.DownloadServerFile(downFileInfo, path);
        }

        public List<DownloadFileResult> BatchDownloadFile(List<DownloadFileInfo> downFiles)
        {
            List<DownloadFileResult> resultList = new List<DownloadFileResult>();

            foreach (var dfi in downFiles)
            {
                resultList.Add(this.DownloadFile(dfi));
            }

            return resultList;
        }

        public UploadFileResult UploadFile(UploadFileInfo uploadFile)
        {
            string path = string.Empty;
            if (string.IsNullOrEmpty(this.filePath))
            {
                path = uploadFile.PhysicalPath;
            }
            else
            {
                path = path + uploadFile.RelativePath;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return this.SaveUploadFile(uploadFile, path);
        }

        public List<UploadFileResult> BatchUploadFile(List<UploadFileInfo> uploadFiles)
        {
            List<UploadFileResult> resultList = new List<UploadFileResult>();

            foreach (var ufi in uploadFiles)
            {
                resultList.Add(this.UploadFile(ufi));
            }

            return resultList;
        }
        /// <summary>
        /// 从服务器上下载文件
        /// </summary>
        /// <param name="fileDownload">文件下载</param>
        /// <param name="path">下载文件路径</param>
        /// <returns></returns>
        private DownloadFileResult DownloadServerFile(DownloadFileInfo downFileInfo, string path)
        {
            DownloadFileResult fdr = new DownloadFileResult();
            FileStream fs = null;
            try
            {
                fdr.FileName = downFileInfo.FileName;
                if (!File.Exists(path))
                {
                    fdr.OperateResult = Data.ResultType.Fail;
                    fdr.RelativePath = downFileInfo.RelativePath;
                    fdr.FileSize = 0;
                    fdr.ResultMessage = "服务器上不存在该文件！Path:" + path;
                    fdr.FileStream = new MemoryStream();
                }
                else
                {
                    Stream s = new MemoryStream();
                    fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    fs.CopyTo(s);
                    s.Position = 0;

                    fdr.OperateResult = Data.ResultType.Success;
                    fdr.RelativePath = downFileInfo.RelativePath;
                    fdr.FileSize = s.Length;
                    fdr.FileStream = s;
                }
            }
            catch (Exception ex)
            {
                fdr.OperateResult = Data.ResultType.Error;
                fdr.RelativePath = downFileInfo.RelativePath;
                fdr.FileSize = 0;
                fdr.ResultMessage = ex.Message;
                fdr.FileStream = new MemoryStream();
            }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                }
            }

            return fdr;
        }
        /// <summary>
        /// 保存上传的文件
        /// </summary>
        /// <param name="fileData">文件信息</param>
        /// <param name="path">存储文件的路径</param>
        /// <returns>返回结果信息</returns>
        private UploadFileResult SaveUploadFile(UploadFileInfo fileData, string path)
        {
            UploadFileResult fu = new UploadFileResult();
            byte[] buffer = new byte[fileData.FileSize];
            FileStream fs = null;

            try
            {
                fu.FileName = fileData.FileName;
                fu.FileSize = fileData.FileSize;
                fu.RelativePath = fileData.RelativePath;

                fs = new FileStream(Path.Combine(path, fileData.FileName), FileMode.Create, FileAccess.Write);
                int count = 0;
                while ((count = fileData.FileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, count);
                }
                fu.OperateResult = Data.ResultType.Success;
            }
            catch (Exception ex)
            {
                fu.OperateResult = Data.ResultType.Error;
                fu.ResultMessage = ex.Message + "文件夹路径：" + path;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                }
            }

            return fu;
        }
    }
}
