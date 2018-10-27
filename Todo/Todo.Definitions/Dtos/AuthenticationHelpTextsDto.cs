namespace NsuGo.Definition.Dtos
{
    public class AuthenticationHelpTextsDto
    {
        /// <summary>
        /// The fingerprint image was incomplete due to quick motion.
        /// </summary>
        public string MovedTooFast { get; set; }

        /// <summary>
        /// The fingerprint image was unreadable due to lack of motion.
        /// </summary>
        public string MovedTooSlow { get; set; }

        /// <summary>
        /// Only a partial fingerprint image was detected.
        /// </summary>
        public string Partial { get; set; }

        /// <summary>
        /// The fingerprint image was too noisy to process due to a detected condition.
        /// </summary>
        public string Insufficient { get; set; }

        /// <summary>
        /// The fingerprint image was too noisy due to suspected or detected dirt on the sensor.
        /// </summary>
        public string Dirty { get; set; }
    }
}
