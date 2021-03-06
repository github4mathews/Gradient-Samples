﻿namespace LostTech.Gradient.Samples {
    using System;
    using System.Linq;
    using Avalonia;
    using Avalonia.Logging.Serilog;
    using LostTech.Gradient;
    using LostTech.TensorFlow;
    using ManyConsole.CommandLineUtils;
    using tensorflow;
    using tensorflow.core.protobuf.config_pb2;

    static class CSharpOrNotProgram {
        public static int Main(string[] args) {
            TensorFlowSetup.Instance.OptInToUsageDataCollection();
            GradientEngine.UseEnvironmentFromVariable();

            dynamic config = config_pb2.ConfigProto.CreateInstance();
            config.gpu_options.allow_growth = true;
            tf.keras.backend.set_session(Session.NewDyn(config: config));

            return ConsoleCommandDispatcher.DispatchCommand(
                ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof(CSharpOrNotProgram)),
                args, Console.Out);
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();
    }
}
