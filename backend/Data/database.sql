IF NOT EXISTS (
	SELECT * FROM sys.databases WHERE name = 'isucorpdb'
)
BEGIN
	CREATE DATABASE isucorpdb
END

USE isucorpdb
GO

IF NOT EXISTS (
	SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Tasks'
)
	BEGIN
		CREATE TABLE Tasks(
			TaskId int identity(1,1),
			Title nvarchar(255) not null,
			Description nvarchar(max) null,
			DueDate datetime2 null,
			IsCompleted bit not null default 0,
			primary key(TaskId)
		)
		
		INSERT INTO Tasks (Title, Description, DueDate, IsCompleted)
		VALUES ('Complete Project Proposal', 'Finalize the project proposal for the upcoming client meeting.', '2024-11-10', 0),
				('Schedule Team Meeting', 'Organize a meeting with the team to discuss project updates and deadlines.', '2024-11-05', 0),
				('Review Budget Report', 'Analyze the budget report and prepare notes for the finance review.', '2024-11-12', 0),
				('Update Website Content', 'Revise the content on the website to reflect the new branding guidelines.', '2024-11-15', 0),
				('Conduct Market Research', 'Gather and analyze data about competitors and market trends.', '2024-11-20', 0),
				('Prepare Presentation Slides', 'Create slides for the upcoming presentation on product features.', '2024-11-07', 0),
				('Test New Software Features', 'Run tests on the new features of the software to ensure functionality.', '2024-11-25', 0),
				('Organize Office Supplies', 'Replenish and organize office supplies for the upcoming quarter.', '2024-11-01', 0),
				('Prepare Training Materials', 'Develop materials for the training session scheduled for next week.', '2024-11-08', 0),
				('Follow Up with Clients', 'Send follow-up emails to clients regarding their feedback on services.', '2024-11-03', 0),
				('Plan Company Event', 'Coordinate the details for the upcoming company-wide event.', '2024-11-18', 0),
				('Review Employee Performance', 'Evaluate employee performance for the quarterly review.', '2024-11-14', 0),
				('Finalize Marketing Strategy', 'Complete the marketing strategy document for the next campaign.', '2024-11-13', 0),
				('Clean Up Project Workspace', 'Organize and clean up the project workspace for better productivity.', '2024-11-02', 0),
				('Conduct User Testing', 'Gather feedback from users on the latest product version.', '2024-11-19', 0),
				('Update Social Media Accounts', 'Post updates and manage content on all social media platforms.', '2024-11-21', 0),
				('Create Backup for Data', 'Ensure all data is backed up and secured in the cloud.', '2024-11-09', 0),
				('Analyze Customer Feedback', 'Review and summarize customer feedback to improve services.', '2024-11-22', 0),
				('Prepare Year-End Reports', 'Compile data for year-end reports for management review.', '2024-11-26', 0),
				('Research New Technologies', 'Investigate emerging technologies that could benefit the company.', '2024-11-30', 0)

	END
ELSE 
	BEGIN
		INSERT INTO Tasks (Title, Description, DueDate, IsCompleted)
		VALUES ('Complete Project Proposal', 'Finalize the project proposal for the upcoming client meeting.', '2024-11-10', 0),
				('Schedule Team Meeting', 'Organize a meeting with the team to discuss project updates and deadlines.', '2024-11-05', 0),
				('Review Budget Report', 'Analyze the budget report and prepare notes for the finance review.', '2024-11-12', 0),
				('Update Website Content', 'Revise the content on the website to reflect the new branding guidelines.', '2024-11-15', 0),
				('Conduct Market Research', 'Gather and analyze data about competitors and market trends.', '2024-11-20', 0),
				('Prepare Presentation Slides', 'Create slides for the upcoming presentation on product features.', '2024-11-07', 0),
				('Test New Software Features', 'Run tests on the new features of the software to ensure functionality.', '2024-11-25', 0),
				('Organize Office Supplies', 'Replenish and organize office supplies for the upcoming quarter.', '2024-11-01', 0),
				('Prepare Training Materials', 'Develop materials for the training session scheduled for next week.', '2024-11-08', 0),
				('Follow Up with Clients', 'Send follow-up emails to clients regarding their feedback on services.', '2024-11-03', 0),
				('Plan Company Event', 'Coordinate the details for the upcoming company-wide event.', '2024-11-18', 0),
				('Review Employee Performance', 'Evaluate employee performance for the quarterly review.', '2024-11-14', 0),
				('Finalize Marketing Strategy', 'Complete the marketing strategy document for the next campaign.', '2024-11-13', 0),
				('Clean Up Project Workspace', 'Organize and clean up the project workspace for better productivity.', '2024-11-02', 0),
				('Conduct User Testing', 'Gather feedback from users on the latest product version.', '2024-11-19', 0),
				('Update Social Media Accounts', 'Post updates and manage content on all social media platforms.', '2024-11-21', 0),
				('Create Backup for Data', 'Ensure all data is backed up and secured in the cloud.', '2024-11-09', 0),
				('Analyze Customer Feedback', 'Review and summarize customer feedback to improve services.', '2024-11-22', 0),
				('Prepare Year-End Reports', 'Compile data for year-end reports for management review.', '2024-11-26', 0),
				('Research New Technologies', 'Investigate emerging technologies that could benefit the company.', '2024-11-30', 0)
	END

GO

IF NOT EXISTS (
	SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME='Users'
)
	BEGIN
		CREATE TABLE Users (
			Id int identity(1,1),
			Username nvarchar(50) not null unique,
			PasswordHash nvarchar(255) not null
			primary key(Id)
		)

		INSERT INTO Users (Username, PasswordHash) 
		VALUES ('admin','admin'), ('demo','demo'), ('icuarezma', 'icuarezma')
	END
ELSE 
	BEGIN
		INSERT INTO Users (Username, PasswordHash) 
		VALUES ('admin','admin'), ('demo','demo'), ('icuarezma', 'icuarezma')
	END	


GO


GO