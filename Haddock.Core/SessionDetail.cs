
using System;
namespace Haddock.Core
{
    /// <summary>
    /// Detail of an individual session.
    /// </summary>
    public class SessionDetail
    {
        /// <summary>
        /// db key.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the assigned team.
        /// </summary>
        public string Team { get; set; }

        /// <summary>
        /// Iteration testing was done in.
        /// </summary>
        public string Iteration { get; set; }

        /// <summary>
        /// Product area name.
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// Which tester.
        /// </summary>
        public string Tester { get; set; }

        /// <summary>
        /// Stated mission of the session.
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

    }
}
