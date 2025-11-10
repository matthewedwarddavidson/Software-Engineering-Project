using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Relationship_manager_administration_system
{
    class DatabaseClass
    {
        private static SqlConnection connection = new SqlConnection("Server=tcp:rmas-server.database.windows.net,1433;Initial Catalog=RelationshipManagerAdministrationSystemDB;Persist Security Info=False;User ID=FreddieFaulkner;Password=Password123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public static DataTable GetPotentialUser(string username, string role)
        {
            DataTable potentialUser = new DataTable();
            SqlDataAdapter adapter;

            connection.Open();
            if (role.Equals("Relationship Manager"))
            {
                adapter = new SqlDataAdapter(@"SELECT rmID, Email, [Password] FROM [dbo].[tblRelationshipManagers] WHERE Email = '" + username + "'", connection);
            }
            else
            {
                adapter = new SqlDataAdapter(@"SELECT icID, email, [password] FROM [dbo].[tblIdeaCreator] WHERE Email = '" + username + "'", connection);
            }

            adapter.Fill(potentialUser);
            connection.Close();

            Debug.WriteLine("getPotentialUser ran");

            return potentialUser;
        }

        public static DataTable GetClients(int rmid)
        {
            DataTable clients = new DataTable();

            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT ClientID, FirstName, LastName, Email, Company, Phone FROM[dbo].[tblClients] WHERE rmID = '" + rmid + "'", connection);
            adapter.Fill(clients);
            connection.Close();

            return clients;
        }

        public static void UpdateClientData(int clientReference, string client, string email, string contactFirst, string contactLast, string contactNumber)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE [dbo].[tblClients] SET Company='" + client + "', Email='" + email + "', FirstName='" + contactFirst + "', LastName='" + contactLast + "', Phone='" + contactNumber + "' WHERE clientID ='" + clientReference + "'", connection);
                command.ExecuteNonQuery();
            }
            catch
            {
                Debug.WriteLine("Empty data fields!");
            }

            connection.Close();

        }

        public static void DeleteClient(int clientReference)
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[tblClients] WHERE ClientID= '" + clientReference + "'", connection);
                command.ExecuteNonQuery();
            }
            catch
            {
                Debug.WriteLine("Empty Data fields!");
            }

            connection.Close();
        }

        public static DataTable getClientEmails()
        {
            DataTable emails = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT Email FROM [dbo].[tblClients]", connection);
            adapter.Fill(emails);
            connection.Close();
            return emails;
        }

        public static void createClient(string client, string email, string contactFirstName, string contactLastName, string contactNumber, int rmID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[tblClients] (FirstName, LastName, Email, Phone, Company, rmID) VALUES ('" + contactFirstName + "', '" + contactLastName + "', '" + email + "', '" + contactNumber + "', '" + client + "', '" + rmID + "');", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void AddIdea(Idea idea, int id)
        {
            connection.Open();
            // https://stackoverflow.com/questions/12393665/the-conversion-of-a-varchar-data-type-to-a-datetime-data-type-resulted-in-an-out
            var sqlFormattedDate = idea.expiary.Date.ToString("yyyy-MM-dd HH:mm:ss");
            SqlCommand command = new SqlCommand($"INSERT INTO [dbo].[tblIdeas] (Title, Summary, ExpiryDate, IdeaCreator, LongDescription, RiskRating, ProductType, Instruments, Currency, MajorSector, MinorSector, Country, Region) VALUES (\'{idea.title}\', \'{idea.summary}\', \'{sqlFormattedDate}\', \'{id}\', \'{idea.description}\', \'{idea.riskRaiting}\', \'{idea.productType}\', \'{idea.instrument}\', \'{idea.currency}\', \'{idea.majorSector}\', \'{idea.minorSector}\', \'{idea.country}\', \'{idea.region}\')", connection);
            Debug.WriteLine($@"INSERT INTO [dbo].[tblIdeas] (Title, Summary, ExpiryDate, IdeaCreator, LongDescription, RiskRating, ProductType, Instruments, Currency, MajorSector, MinorSector, Country, Region) VALUES ({idea.title}, {idea.summary}, {Convert.ToDateTime(idea.expiary)}, {id}, {idea.description}, {idea.riskRaiting}, {idea.productType}, {idea.instrument}, {idea.currency}, {idea.majorSector}, {idea.minorSector}, {idea.country}, {idea.region})");
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataTable GetMyIdeas(int id)
        {
            DataTable ideas = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT Title, Summary, ExpiryDate, LongDescription, RiskRating, ProductType, Instruments, Currency, MajorSector, MinorSector, Country, Region FROM [dbo].[tblIdeas] WHERE IdeaCreator= '" + id + "'", connection);
            adapter.Fill(ideas);
            connection.Close();
            return ideas;
        }

        public static void updatePreferences(Preferences newPreferences, int clientId)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE [dbo].[tblClients] SET riskRaitingPreference = '" + newPreferences.riskRaiting + "', productTypePreference = '" + newPreferences.productType + "', CurencyPreferences = '" + newPreferences.currency + "', MajorSectorPreferences = '" + newPreferences.majorSector + "', MinorSectorPreferences = '" + newPreferences.minorSector + "', countryPreference = '" + newPreferences.country + "' WHERE clientID = '" + clientId + "'", connection);
            command.ExecuteNonQuery();
            Debug.WriteLine("UPDATE [dbo].[tblClients] SET riskRaitingPreference = '" + newPreferences.riskRaiting + "', productTypePreference = '" + newPreferences.productType + "', CurencyPreferences = '" + newPreferences.currency + "', MajorSectorPreferences = '" + newPreferences.majorSector + "', MinorSectorPreferences = '" + newPreferences.minorSector + "', countryPreference = '" + newPreferences.country + "' WHERE clientID = '" + clientId + "'");
            connection.Close();
        }

        public static DataTable getPreferences(int clientID)
        {
            DataTable preferences = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT riskRaitingPreference, productTypePreference, CurencyPreferences, MajorSectorPreferences, MinorSectorPreferences, CountryPreference FROM [dbo].[tblClients] WHERE clientId= '" + clientID + "'", connection);
            adapter.Fill(preferences);
            connection.Close();
            return preferences;
        }

        public static DataTable getReleventIdeas(Preferences preferences)
        {
            DataTable ideas = new DataTable();
            connection.Open();
            // https://stackoverflow.com/questions/12393665/the-conversion-of-a-varchar-data-type-to-a-datetime-data-type-resulted-in-an-out
            var sqlFormattedDate = DateTime.Today.Date.ToString("yyyy-MM-dd HH:mm:ss");
            SqlDataAdapter adapter = new SqlDataAdapter($"SELECT Title, Summary, ExpiryDate, LongDescription, RiskRating, ProductType, Instruments, Currency, MajorSector, MinorSector, Country, Region FROM [dbo].[tblIdeas] WHERE (RiskRating <= {preferences.riskRaiting}) AND (ProductType = \'{preferences.productType}\') AND (Currency = \'{preferences.currency}\') AND MajorSector = \'{preferences.majorSector}\' AND (MinorSector= \'{preferences.minorSector}\') AND (Country= \'{preferences.country}\') AND (ExpiryDate > \'{sqlFormattedDate}\') AND (OwnedBy IS NULL)", connection);
            Debug.WriteLine($"SELECT Title, Summary, ExpiryDate, LongDescription, RiskRating, ProductType, Instruments, Currency, MajorSector, MinorSector, Country, Region FROM [dbo].[tblIdeas] WHERE (RiskRating <= {preferences.riskRaiting}) AND (ProductType = {preferences.productType}) AND (Currency = {preferences.currency}) AND MajorSector = {preferences.majorSector} AND (MinorSector= {preferences.minorSector}) AND (Country= {preferences.country}) AND (ExpiayDate > {DateTime.Today}) AND (OwnedBy IS NULL)");
            adapter.Fill(ideas);
            connection.Close();
            return ideas;
        }

        public static void purchaseProduct(string productTitle, int clientReference)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE [dbo].[tblIdeas] SET OwnedBy = '" + clientReference + "' WHERE title = '" + productTitle + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataTable getIC(int icID) {
            DataTable ic = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT icID, email, [password] FROM [dbo].[tblIdeaCreator] WHERE icID = '" + icID +"'", connection);
            adapter.Fill(ic);
            connection.Close();
            return ic;
        }


        public static DataTable getRM(int rmID){
            DataTable rm = new DataTable();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(@"SELECT rmID, email, [password] FROM [dbo].[tblrelationshipmanagerr] WHERE rmID = '" + rmID + "'", connection);
            adapter.Fill(rm);
            connection.Close();
            return rm;
    
        }
        public static void updateIdea(int icid, string title, Idea idea)
        {
            connection.Open();
            // https://stackoverflow.com/questions/12393665/the-conversion-of-a-varchar-data-type-to-a-datetime-data-type-resulted-in-an-out
            var sqlFormattedDate = idea.expiary.Date.ToString("yyyy-MM-dd HH:mm:ss");
            SqlCommand command = new SqlCommand($"UPDATE [dbo].[tblIdeas] SET Summary='{idea.summary}', ExpiryDate='{sqlFormattedDate}', IdeaCreator={icid}, LongDescription='{idea.description}', RiskRating={idea.riskRaiting}, ProductType='{idea.productType}', Instruments='{idea.instrument}', Currency='{idea.currency}', MajorSector='{idea.majorSector}', MinorSector='{idea.minorSector}', Country='{idea.country}', Region='{idea.region}' WHERE title='{title}'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void deleteIdea(string title)
        {
            connection.Open();
            SqlCommand command = new SqlCommand($"DELETE FROM [dbo].[tblIdeas] WHERE Title='{title}'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataTable getIdeas()
        {
            connection.Open();
            DataTable ideas = new DataTable();
            SqlDataAdapter ideasAdapter = new SqlDataAdapter(@"SELECT Title, Summary, ExpiryDate, LongDescription, RiskRating, ProductType, Instruments, Currency, MajorSector, MinorSector, Country, Region FROM [dbo].[tblIdeas] WHERE ownedBy IS NOT NULL", connection);
            ideasAdapter.Fill(ideas);
            connection.Close();
            return ideas;
        }

        public static void removeIdea(string title)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE [dbo].[tblIdeas] SET ownedBy = NULL WHERE Title= '" + title + "'", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DataTable getShortIdea()
        {
            connection.Open();
            DataTable ideas = new DataTable();
            SqlDataAdapter ideasAdapter = new SqlDataAdapter(@"SELECT Title, Summary, LongDescription, ownedBy FROM [dbo].[tblIdeas] WHERE ownedBy IS NOT NULL", connection);
            ideasAdapter.Fill(ideas);
            connection.Close();
            return ideas;
        }
    }
}
