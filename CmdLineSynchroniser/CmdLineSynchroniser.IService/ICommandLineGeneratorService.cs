using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmdLineSynchroniser.IRepository.DTOs;
using CmdLineSynchroniser.IService.DTOs;

namespace CmdLineSynchroniser.IService
{
    public interface ICommandLineGeneratorService
    {
        int GenerateCommandLineTextFile(SybaseInfo sybaseInfo, string outputPath, string sqlXmlPath,string eodDate, FileHanlder fileHanlder);
    }
}
