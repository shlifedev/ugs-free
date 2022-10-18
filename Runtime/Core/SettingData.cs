namespace UGS.Runtime
{ 
    [System.Serializable]
    public class SettingData
    {
        public SettingData(string driveId, string scriptDeploymentId)
        {
            DriveId = driveId;
            ScriptDeploymentId = scriptDeploymentId;
        }

        /// <summary>
        /// Drive Id
        /// </summary>
        public string DriveId { get; set; }
        /// <summary>
        /// 스크립트가 배포된 Id 
        /// </summary>
        public string ScriptDeploymentId { get; set; }
    }
}