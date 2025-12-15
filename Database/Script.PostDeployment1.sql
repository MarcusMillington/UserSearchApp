/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS(SELECT TOP 1 1 FROM [User])
BEGIN

    INSERT INTO [User]([FirstName], [LastName], [JobRole], [Telephone], Email)
    VALUES
        ('David', 'Jones', 'Developer', '07789 543768', 'djones@test.com'),
        ('Lisa', 'Holmes', 'Development Lead', '07756 896512', 'lholmes@test.com'),
        ('Alex', 'Smith', 'QA Lead', '07723 743289', 'asmith@test.com'),
        ('Kieran', 'James', 'Developer', '07898 654123', 'kjames@test.com'),
        ('Gavin', 'Miles', 'UX Designer', '07881 987554', 'gmiles@test.com'),
        ('Kathy', 'Smith', 'UX Lead', '07765 332287', 'ksmith@test.com'),
        ('Phil', 'Walker', 'Senior QA', '07889 984447', 'pwalker@test.com'),
        ('Rebecca', 'Bates', 'Product Development Manager', '07798 548733', 'rbates@test.com'),
        ('Hayley', 'Walker-Smith', 'Developer', '07888 932145', 'hwalker@test.com'),
        ('Alexis', 'Crawley', 'DevOps Engineer', '07778 667412', 'acrawley@test.com'),
        ('David', 'Gold', 'DevOps Engineer', '07768 479563', 'dgold@test.com'),
        ('Phillipa', 'Walker', 'QA Lead', '07775 357951', 'pwalker2@test.com')

END