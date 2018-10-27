using NsuGo.DatabaseAccess.DataMappers;
using NsuGo.DatabaseAccess.Repositories;
using NsuGo.Definition.Interfaces;
using NsuGo.Definition.Interfaces.Repositories.Local;
using NsuGo.Definition.Models;
using NsuGo.Framework.Interfaces;
using LocalData = Todo.LocalData.Models;

namespace NsuGo.DatabaseAccess.Configuration
{
    public static class Dependency
    {
        public static void Init(IInjection injection)
        {
            Todo.LocalData.Configuration.Dependency.Init(injection);

            RegisterDataMappers(injection);
            RegisterRepositories(injection);
        }

        private static void RegisterDataMappers(IInjection injection)
        {
            injection.Register<IDataMapper<Course, LocalData.Course>, CourseMapper>();
            injection.Register<IDataMapper<AccountHold, LocalData.AccountHold>, AccountHoldMapper>();
            injection.Register<IDataMapper<Term, LocalData.Term>, TermMapper>();
            injection.Register<IDataMapper<Announcement, LocalData.Announcement>, AnnouncementMapper>();
            injection.Register<IDataMapper<Assignment, LocalData.Assignment>, AssignmentMapper>();
            injection.Register<IDataMapper<UserProfile, LocalData.User>, UserAccountMapper>();
            injection.Register<IDataMapper<Grade, LocalData.Grade>, GradeMapper>();
            injection.Register<IDataMapper<Folder, LocalData.Folder>, FolderMapper>();
            injection.Register<IDataMapper<File, LocalData.File>, FileMapper>();
            injection.Register<IDataMapper<Content, LocalData.Content>, ContentMapper>();
            injection.Register<IDataMapper<AccountSummary, LocalData.AccountSummary>, AccountSummaryMapper>();
            injection.Register<IDataMapper<Staff, LocalData.Staff>, StaffMapper>();
        }

        private static void RegisterRepositories(IInjection injection)
        {
            injection.Register<ITermRepository, TermRepository>();
            injection.Register<IUserAccountRepository, UserAccountRepository>();
            injection.Register<ICourseRepository, CourseRepository>();
            injection.Register<IAssignmentRepository, AssignmentRepository>();
            injection.Register<IAnnouncementRepository, AnnouncementRepository>();
            injection.Register<IGradeRepository, GradeRepository>();
            injection.Register<IContentRepository, ContentRepository>();
            injection.Register<IFolderRepository, FolderRepository>();
            injection.Register<IFileRepository, FileRepository>();
            injection.Register<IAccountSummaryRepository, AccountSummaryRepository>();
            injection.Register<IAccountHoldRepository, AccountHoldRepository>();
            injection.Register<IStaffRepository, StaffRepository>();
            injection.Register<IStaffCourseRosterRepository, StaffCourseRosterRepository>();
        }


    }
}
