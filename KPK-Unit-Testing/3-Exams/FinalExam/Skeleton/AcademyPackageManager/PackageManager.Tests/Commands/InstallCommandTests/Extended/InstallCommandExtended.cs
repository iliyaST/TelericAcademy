using PackageManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests.Extended
{
    internal class InstallCommandExtended : InstallCommand
    {
        public InstallCommandExtended(IInstaller<IPackage> installer, IPackage package)
            : base(installer, package)
        {
        }

        public IInstaller<IPackage> GetInstaller
        {
            get
            {
                return this.Installer;
            }
        }

        public IPackage GetPackage
        {
            get
            {
                return this.Package;
            }
        }

    }
}
