public class BusinessCaseMaster
{
    public List<BusinessCase> businessCaseList;

    public List<string> CreateMenu()
    {
        List<string> output = new();
        businessCaseList.ForEach(x => output.Add(x.BusinessCaseName));
        return output;
    }
}