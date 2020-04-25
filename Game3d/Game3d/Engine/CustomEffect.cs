//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;  

//namespace Game3d
//{
//    public class CustomEffect //: BaseGameScript
//    {
//        const string fxCompilerFilepath = @"C:\Program Files (x86)\MSBuild\MonoGame\v3.0\Tools\2MGFX.exe";
//        private readonly ILogger logger;
//        private readonly GraphicsDevice GraphicsDevice;
//        private readonly string fxShaderFilepath;

//        public Effect effect;

//        public CustomEffect(ILogger logger, GraphicsDevice GraphicsDevice, string fxShaderFilepath)
//        {
//            this.logger = logger;
//            this.GraphicsDevice = GraphicsDevice;
//            this.fxShaderFilepath = fxShaderFilepath;
//        }   
         
//        public void Initialise()
//        {  
//            var mgfxoFilepath = fxShaderFilepath.Remove(fxShaderFilepath.Length - 2) + "mgfxo";
             
//            var compilerProcess = new Process();
//            compilerProcess.StartInfo.FileName = fxCompilerFilepath;
//            compilerProcess.StartInfo.Arguments = $"{fxShaderFilepath} {mgfxoFilepath} /debug /Profile:DirectX_11";
//            compilerProcess.OutputDataReceived += CompilerProcess_OutputDataReceived;
//            compilerProcess.ErrorDataReceived += CompilerProcess_ErrorDataReceived; 
//            compilerProcess.EnableRaisingEvents = true;
//            compilerProcess.StartInfo.RedirectStandardError = true;
//            compilerProcess.StartInfo.RedirectStandardOutput = true;
//            compilerProcess.StartInfo.UseShellExecute = false; 
//            compilerProcess.StartInfo.CreateNoWindow = true;
//            compilerProcess.Start();
//            compilerProcess.BeginOutputReadLine(); 
//            compilerProcess.WaitForExit();  

//            using (var fs = new FileStream(mgfxoFilepath, FileMode.Open))
//            {
//                var reader = new BinaryReader(fs);
//                effect = new Effect(GraphicsDevice, reader.ReadBytes((int)reader.BaseStream.Length));
//            }
//        }   

//        private void CompilerProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
//        {
//            logger.WriteLine("2MGFX: " + e.Data);
//        }

//        private void CompilerProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
//        {
//            logger.WriteLine("2MGFX: " + e.Data);
//        }
//    }
//} 
