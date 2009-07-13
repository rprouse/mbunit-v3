// Copyright 2005-2009 Gallio Project - http://www.gallio.org/
// Portions Copyright 2000-2004 Jonathan de Halleux
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Globalization;
using Gallio.Model.Isolation;
using Gallio.Runtime.Logging;

namespace Gallio.AutoCAD.Isolation
{
    /// <summary>
    /// A test isolation provider that launches AutoCAD and runs tasks remotely.
    /// </summary>
    public class AcadTestIsolationProvider : BaseTestIsolationProvider
    {
        /// <summary>
        /// Creates a test isolation provider.
        /// </summary>
        public AcadTestIsolationProvider()
        {
        }

        /// <inheritdoc />
        protected override ITestIsolationContext CreateContextImpl(TestIsolationOptions testIsolationOptions, ILogger logger)
        {
            string acadAttachToExisting = testIsolationOptions.Properties.GetValue("AcadAttachToExisting");
            bool acadAttachToExistingBool = false;
            if (acadAttachToExisting != null)
                bool.TryParse(acadAttachToExisting, out acadAttachToExistingBool);

            string acadExePath = testIsolationOptions.Properties.GetValue("AcadExePath");

            AcadProcessFactory processFactory = new AcadProcessFactory(logger)
            {
                AttachToExistingProcess = acadAttachToExistingBool,
                AcadExePath = acadExePath
            };

            return new AcadTestIsolationContext(logger, processFactory);
        }
    }
}