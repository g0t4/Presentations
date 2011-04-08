namespace Refactoring
{
	public class TechnicalDebt
	{
		public static void ForReals()
		{
			//DataSet aDs, qDs;
			//aDs = _dbConnector.UpdateAgentList();
			//qDs = _dbConnector.GetQueueList();
			//foreach (DataTable aTable in aDs.Tables)
			//{
			//  foreach (DataRow aRow in aTable.Rows)
			//  {
			//    foreach (DataColumn aColumn in aTable.Columns)
			//    {
			//      DataSet asDs = _dbConnector.GetAgentSkills(aRow[aColumn].ToString());//AgentId
			//      foreach (DataTable asTable in asDs.Tables)
			//      {
			//        foreach (DataRow asRow in asTable.Rows)
			//        {
			//          foreach (DataColumn asColumn in asTable.Columns)
			//          {
			//            foreach (DataTable qTable in qDs.Tables)
			//            {
			//              foreach (DataRow qRow in qTable.Rows)
			//              {
			//                foreach (DataColumn qColumn in qTable.Columns)
			//                {
			//                  DataSet sqDs = _dbConnector.GetSkillsForQueue(qRow[qColumn].ToString());
			//                  foreach (DataTable sqTable in sqDs.Tables)
			//                  {
			//                    foreach (DataRow sqRow in sqTable.Rows)
			//                    {
			//                      foreach (DataColumn sqColumn in sqTable.Columns)
			//                      {
			//                        foreach (string skill in sqRow[sqColumn].ToString().Split(paramDelimStr))
			//                        {
			//                          if (skill == asRow[asColumn].ToString())
			//                          {
			//                            try
			//                            {
			//                              //Add it to the table
			//                              _dbConnector.SetAgentQueueSkill(aRow[aColumn].ToString(),
			//                                qRow[qColumn].ToString(),
			//                                skill);
			//                            }
			//                            catch { continue; }
			//                          }
			//                        }
			//                      }
			//                    }
			//                  }
			//                }
			//              }
			//            }
			//          }
			//        }
			//      }
			//    }
			//  }
		}
	}
}