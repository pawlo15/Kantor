CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Currency" (
    "Id" smallint NOT NULL,
    "Code" text NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_Currency" PRIMARY KEY ("Id")
);

CREATE TABLE "OperationType" (
    "Id" smallint NOT NULL,
    "Name" text NOT NULL,
    CONSTRAINT "PK_OperationType" PRIMARY KEY ("Id")
);

CREATE TABLE "User" (
    "Id" uuid NOT NULL,
    "Login" text NOT NULL,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "SecureKey" text NOT NULL,
    CONSTRAINT "PK_User" PRIMARY KEY ("Id")
);

CREATE TABLE "UserOperation" (
    "Id" integer GENERATED BY DEFAULT AS IDENTITY,
    "Name" text NOT NULL,
    CONSTRAINT "PK_UserOperation" PRIMARY KEY ("Id")
);

CREATE TABLE "Credentials" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "PasswordHash" bytea NOT NULL,
    "PasswordSalt" bytea NOT NULL,
    CONSTRAINT "PK_Credentials" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Credentials_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "OperationHistory" (
    "Id" uuid NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "Value" numeric NOT NULL,
    "ExchangeRate" numeric NOT NULL,
    "TotalValue" numeric NOT NULL,
    "CurrencyId" smallint NOT NULL,
    "OperationTypeId" smallint NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_OperationHistory" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_OperationHistory_Currency_CurrencyId" FOREIGN KEY ("CurrencyId") REFERENCES "Currency" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_OperationHistory_OperationType_OperationTypeId" FOREIGN KEY ("OperationTypeId") REFERENCES "OperationType" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_OperationHistory_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "UserHistory" (
    "Id" uuid NOT NULL,
    "Action" text NOT NULL,
    "Date" timestamp with time zone NOT NULL,
    "UserId" uuid NOT NULL,
    "OperationId" integer NOT NULL,
    CONSTRAINT "PK_UserHistory" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_UserHistory_UserOperation_OperationId" FOREIGN KEY ("OperationId") REFERENCES "UserOperation" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_UserHistory_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Credentials_UserId" ON "Credentials" ("UserId");

CREATE INDEX "IX_OperationHistory_CurrencyId" ON "OperationHistory" ("CurrencyId");

CREATE INDEX "IX_OperationHistory_OperationTypeId" ON "OperationHistory" ("OperationTypeId");

CREATE INDEX "IX_OperationHistory_UserId" ON "OperationHistory" ("UserId");

CREATE INDEX "IX_UserHistory_OperationId" ON "UserHistory" ("OperationId");

CREATE INDEX "IX_UserHistory_UserId" ON "UserHistory" ("UserId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240512161101_Init', '8.0.3');

COMMIT;

START TRANSACTION;

CREATE TABLE "Account" (
    "Id" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    CONSTRAINT "PK_Account" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Account_User_UserId" FOREIGN KEY ("UserId") REFERENCES "User" ("Id") ON DELETE CASCADE
);

CREATE TABLE "AccountBalance" (
    "Id" uuid NOT NULL,
    "AccountId" uuid NOT NULL,
    "CurrencyId" smallint NOT NULL,
    "Balance" numeric NOT NULL,
    CONSTRAINT "PK_AccountBalance" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_AccountBalance_Account_AccountId" FOREIGN KEY ("AccountId") REFERENCES "Account" ("Id") ON DELETE CASCADE,
    CONSTRAINT "FK_AccountBalance_Currency_CurrencyId" FOREIGN KEY ("CurrencyId") REFERENCES "Currency" ("Id") ON DELETE CASCADE
);

CREATE UNIQUE INDEX "IX_Account_UserId" ON "Account" ("UserId");

CREATE INDEX "IX_AccountBalance_AccountId" ON "AccountBalance" ("AccountId");

CREATE INDEX "IX_AccountBalance_CurrencyId" ON "AccountBalance" ("CurrencyId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240518103504_AddAccounts', '8.0.3');

COMMIT;
