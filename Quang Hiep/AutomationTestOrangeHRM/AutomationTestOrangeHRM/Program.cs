using AutomationTestOrangeHRM;

PostStatusHandler statusHandler = new PostStatusHandler();
string status = "This is status number 1";
for(int i =1; i < 51; i++)
{
    statusHandler.PostStatus(status + i.ToString());   
}
