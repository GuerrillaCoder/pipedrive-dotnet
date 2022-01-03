namespace Pipedrive
{
    public enum Visibility
    {
        //https://devcommunity.pipedrive.com/t/new-field-lead-default-visibility-in-the-roles-api/4255
        //changes depending on account level
        @private = 1,
        shared = 3,
        ownerAndBelow = 5,
        entireCompany = 7
    }
}
