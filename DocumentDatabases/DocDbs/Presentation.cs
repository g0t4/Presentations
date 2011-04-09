namespace DocDbs
{
	public class Presentation
	{
		public void Title()
		{
			/*
			 * 
			 * Relaxing the schema: document databases
			 * 
			 */
		}

		public void Intro()
		{
			/*
			 * 
			 * Wes McClure
			 * Twitter/GitHub: g0t4	
			 * Gmail: wes.mcclure	
			 * 
			 */
		}

		public void WhatIsADocumentDatabase()
		{
			/* http://highscalability.com/blog/2010/9/5/hilarious-video-relational-database-vs-nosql-fanbois.html
			 *	NOT JUST PERFORMANCE/SCALABILITY
			 */

			/* Document based
			 *	Semi-structured
			 *		JSON/XML
			 *		Consistent
			 *	Flexible schema
			 * Indexable Key/Value store
			 */

			/*
			 * Intra v Inter document joins
			 */

			// Lots of buzz

			/*
			 * Not ACID - outside a document
			 * JOINs
			 * 
			 */
		}

		public void LeveragingTheDocument()
		{
			Logging();
		}

		private void Logging()
		{
			/* Uses:
			 *	Lots of message types
			 *	Logging metadata
			 *	Ad hoc queries
			 */

			/* Solutions:
			 * Flat files
			 *	Hard to query
			 *	Inconsistent string serialization
			 * RDBMS
			 *	Hard to query
			 *	Hard to serialize
			 * Doc DBs
			 *	No friction!
			 *	Ad hoc queries
			 *	Flexible storage
		 	 */
		}

		public void CouchResources()
		{
			// http://couchdb.apache.org/

			// CouchDB Service (installer)
			// http://wiki.apache.org/couchdb/Windows_binary_installer

			// Hammock .Net Client
			// http://code.google.com/p/relax-net/
			// Others
			// http://wiki.apache.org/couchdb/Getting_started_with_C%23
			// Divan
			// Relax

			// Built-in Futon Web UI
			// http://localhost:5984/_utils/
		}

		public void RavenDbResources()
		{
			// http://ravendb.net/download
			// Service w/ installer
			// Web UI
			// .Net LINQ API
		}

		public void MongoResources()
		{
			// MongoDB Service (installer)
			// http://www.mongodb.org/downloads

			// Official Mongo Driver
			// http://www.mongodb.org/display/DOCS/CSharp+Language+Center

			// Norm .Net Client
			// https://github.com/atheken/NoRM

			// RockMongo (php) web UI
			// http://code.google.com/p/rock-php/wiki/rock_mongo
		}
	}
}