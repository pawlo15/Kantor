INSERT INTO public."UserOperation"(
	"Id", "Name")
	VALUES (1, 'Registration'),(2, 'SecureKeyGeneration'),(3, 'PasswordChange'),(4, 'EmailChange'),(5, 'NameChange');

INSERT INTO public."Currency"(
	"Id", "Code", "Name")
	VALUES (1, 'EUR', 'Euro'),(2, 'USD', 'Dolar Amerykański'),(3, 'GBP', 'Funt Brytyjski'),(4, 'CHF', 'Frank Szwajcarski'),(5, 'PLN', 'Złoty Polski');

INSERT INTO public."OperationType"(
	"Id", "Name")
	VALUES (1, 'Purchase'),(2, 'Sale');