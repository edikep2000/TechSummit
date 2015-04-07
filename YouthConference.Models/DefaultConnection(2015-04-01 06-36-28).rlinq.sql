-- Dropping index 'UQ__UserProf__C9F2845624BEE0D8' which is not configured in OpenAccess but exists on the database.
DROP INDEX [UQ__UserProf__C9F2845624BEE0D8] ON [UserProfile]

go

-- YouthConference.Models.Registrant
CREATE TABLE [Registrant] (
    [Email] varchar(255) NOT NULL,          -- _email
    [FirstName] varchar(255) NOT NULL,      -- _firstName
    [Gender] varchar(255) NOT NULL,         -- _gender
    [Id] int IDENTITY NOT NULL,             -- _id
    [Institution] varchar(255) NULL,        -- _institution
    [LastName] varchar(255) NOT NULL,       -- _lastName
    [MiddleName] varchar(255) NOT NULL,     -- _middleName
    [PhoneNumber] varchar(255) NOT NULL,    -- _phoneNumber
    [stte] varchar(255) NOT NULL,           -- _state
    CONSTRAINT [pk_Registrant] PRIMARY KEY ([Id])
)

go

-- Column was read from database as: [UserName] nvarchar(56) not null
-- modify column for field _userName
ALTER TABLE [UserProfile] ALTER COLUMN [UserName] varchar(255) NULL

go

