// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IoC.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace VHS.DependencyResolution
{
    using StructureMap;
    using Services;
    using Interface;
    using Services.Interface;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c =>
            {
                c.AddRegistry<DefaultRegistry>();
                c.For<IAccount>().Use<AccountService>();
                c.For<IProfile>().Use<ProfileService>();
                c.For<IProperty>().Use<PropertyService>();
                c.For<IManageProperty>().Use<ManagePropertyService>();
                c.For<IManageRm>().Use<ManageRmService>();
                c.For<INotificationService>().Use<NotificationService>();
                c.For<IAdminHome>().Use<AdminService>();
                c.For<ICategoryService>().Use<CategoryService>();
                c.For<IHomeService>().Use<HomeService>();
                c.For<IPropertyBooking>().Use<PropertyBookingService>();
                c.For<IManageBookingService>().Use<ManageBookingService>();
                //c.For<IAccount>().Use<AccountService>();
                //c.For<IProfile>().Use<ProfileService>();
                //c.For<IAccount>().Use<AccountService>();
                //c.For<IProfile>().Use<ProfileService>();
            });
        }
    }
}