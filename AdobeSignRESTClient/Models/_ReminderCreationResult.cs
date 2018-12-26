namespace AdobeSignRESTClient.Models
{
    public class _ReminderCreationResult
    {
        /// <summary>
        /// A status value indicating the result of the operation
        /// </summary>
        public string result { get; set; }
        /// <summary>
        /// The info of the party (participant sets) that was reminded.
        /// </summary>
        public _ParticipantEmailSetInfo[] participantEmailSetInfo { get; set; }
    }
}
