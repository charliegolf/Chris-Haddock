
namespace Haddock.Web.ViewModels
{
    using System;

    /// <summary>
    /// Simple session model used for view and create/edit.
    /// </summary>
    public class SessionEditModel
    {
        /// <summary>
        /// Db key
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Team Db Key
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// Iteration Db Key
        /// </summary>
        public int IterationId { get; set; }

        /// <summary>
        /// Product Area Db Key
        /// </summary>
        public int ProductAreaId { get; set; }

        /// <summary>
        /// Tester Db Key
        /// </summary>
        public int TesterId { get; set; }

        /// <summary>
        /// Mission of the session
        /// </summary>
        public string Mission { get; set; }

        /// <summary>
        /// Machine setup
        /// </summary>
        public string Setup { get; set; }

        /// <summary>
        /// When this session was started.
        /// </summary>
        public DateTime Started { get; set; }

        /// <summary>
        /// Risks that are the focus of this session.
        /// </summary>
        public string RisksToMitigate { get; set; }

        /// <summary>
        /// Tasks in this session.
        /// </summary>
        public string Tasks { get; set; }

        /// <summary>
        /// Bugs identified in this session.
        /// </summary>
        public string Bugs { get; set; }

        /// <summary>
        /// Issues identified in this session.
        /// </summary>
        public string Issues { get; set; }

        /// <summary>
        /// Notes collected in this session.
        /// </summary>
        public string Notes { get; set; }

        /// <summary>
        /// Handover notes collected in this session.
        /// </summary>
        public string Handover { get; set; }

        /// <summary>
        /// When this session was ended.
        /// </summary>
        public DateTime Ended { get; set; }

        /// <summary>
        /// Length of this session 
        /// </summary>
        public string Duration 
        {
            get
            {
                if (this.Started == DateTime.MinValue)
                    return "Not started";

                if (this.Ended == DateTime.MinValue)
                    return "Open";

                TimeSpan length = this.Ended - this.Started;

                return length.ToString("h'h 'm'm 's's'");
            }
        }

    }
}