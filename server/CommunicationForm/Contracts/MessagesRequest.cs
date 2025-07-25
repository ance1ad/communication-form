namespace CommunicationForm.API.Contracts
{
    public record MessagesRequest 
    (
        string Text,
        ContactDto Contact,
        ThemeDto Theme
    );

}
