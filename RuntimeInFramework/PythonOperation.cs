using System;
using System.IO;
using Python.Runtime;

namespace RuntimeInFramework
{
    public class PythonOperation
    {
        PyScope scope;

        public PythonOperation() { }

        public void Initialize()
        {
            try
            {
                PythonEngine.Initialize();
                scope = Py.CreateScope();
            }
            catch
            {
            }
        }

        public void Execute()
        {
            // Сгенерированный JSON объекты Prediction.
            var arg = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files", @"data.json"));

            using (Py.GIL())
            {
                scope.Exec(
                    // передаем тескт скрипта
                    File.ReadAllText(
                        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Files", @"script.py")));

                // Запускаем необходимый нам метод в скрипте Python
                // и получаем возврощаемое значение
                var res = scope.Eval($"predict('{arg}')");

                Console.WriteLine(res);
            }
        }
    }
}
