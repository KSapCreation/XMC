<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        RegisterRoutes(RouteTable.Routes);
    }
    
    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("DashBoard#One", "Admin/DashBoard", "~/Admin/index.aspx");
        routes.MapPageRoute("UserMaster#One", "Admin/UserMaster", "~/Admin/UserMaster.aspx");
        routes.MapPageRoute("About#One", "Admin/About", "~/Admin/About.aspx");
        routes.MapPageRoute("Gallery#One", "Admin/Gallery", "~/Admin/Gallery.aspx");
        routes.MapPageRoute("Program#One", "Admin/Programs", "~/Admin/Programs.aspx");
        routes.MapPageRoute("RegisterList", "Admin/RegisterList", "~/Admin/RegisterList.aspx");
        routes.MapPageRoute("Panels#One", "Admin/Panels", "~/Admin/Panels.aspx");
        routes.MapPageRoute("OthersInfo", "Admin/OthersInfo", "~/Admin/Others.aspx");
        routes.MapPageRoute("Category#One", "Admin/Category", "~/Admin/Category.aspx");
        routes.MapPageRoute("Batches", "Admin/Batches", "~/Admin/Batches.aspx");
        routes.MapPageRoute("Study", "Admin/Study", "~/Admin/StudyMaster.aspx");
        routes.MapPageRoute("Subject#One", "Admin/Subject", "~/Admin/Subject.aspx");
        routes.MapPageRoute("Section#One", "Admin/Section", "~/Admin/Section.aspx");
        routes.MapPageRoute("Series#One", "Admin/Series", "~/Admin/Series.aspx");
        routes.MapPageRoute("ExamMaster", "Admin/ExamMaster", "~/Admin/ExamListMaster.aspx");
        routes.MapPageRoute("Question", "Admin/Question", "~/Admin/WebForm.aspx");
        routes.MapPageRoute("Audio", "Admin/Audio", "~/Admin/AVMaster.aspx");
        routes.MapPageRoute("Video", "Admin/Video", "~/Admin/VideoMaster.aspx");
        routes.MapPageRoute("Comprehension", "Admin/Comprehension", "~/Admin/Comprehension.aspx");
        routes.MapPageRoute("TearmsCondition", "Admin/TearmsCondition", "~/Admin/TearmsCondition.aspx");
        routes.MapPageRoute("Updates", "Admin/Updates", "~/Admin/UpdatesInfo.aspx");
        routes.MapPageRoute("MyAccount", "Exam/MyAccount", "~/Exam/Studenthome.aspx");
        routes.MapPageRoute("ListExam", "Exam/ListExam", "~/Exam/ListExam.aspx");
        routes.MapPageRoute("Result", "Exam/Result", "~/Exam/Result.aspx");
        routes.MapPageRoute("FBNPCTearms", "Exam/FBNPCTearms", "~/Exam/FBNPCTearms.aspx");
        routes.MapPageRoute("StartExam", "Exam/StartExam", "~/Exam/Page.aspx");
      routes.MapPageRoute("Achiever", "Admin/Achiever", "~/Admin/Achiever.aspx");
        routes.MapPageRoute("Country", "Admin/Country", "~/Admin/CountryMaster.aspx");
        routes.MapPageRoute("State", "Admin/State", "~/Admin/StateMaster.aspx");
        routes.MapPageRoute("City", "Admin/City", "~/Admin/CityMaster.aspx");
        routes.MapPageRoute("Blogs", "Admin/Blogs", "~/Admin/Blogs.aspx");
    }
</script>

