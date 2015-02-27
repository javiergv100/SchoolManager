﻿using SchoolManager.Entities;
using SchoolManager.Infrastructure;
using SchoolManager.Services.Download;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManager.Services.Data;

namespace SchoolManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Injector.SetupContainer();
            var schoolDownloader = Injector.Container.GetInstance<ISchoolDownloader>();
            var dataTableBuilder = Injector.Container.GetInstance<IDataTableBuilder>();
            var excelPackageCreator = Injector.Container.GetInstance<IExcelPackageCreator>();

            Task.Run(async () =>
                {
                    var students = await schoolDownloader.GetStudentsAsync();
                   

                    IList<Tuple<Teacher, IList<Student>>> teachersWithStudents =
                        teachers
                        .Select(teacherWithClasses =>
                            new Tuple<Teacher, IList<Student>>(teacherWithClasses, students
                                     .Where(studentWithClasses => studentWithClasses.Classes.Any(teacherWithClasses.Classes.Contains))
                                     .ToList())
                           ).ToList();

                    //dotNETSpain2015 Hands-On-Lab
                    excelPackageCreator.CreateAndSaveExcelPackage(dt);

                }).Wait();
        }
    }
}
