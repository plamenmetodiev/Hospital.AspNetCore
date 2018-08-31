USE [HospitalDb]
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (1, 'PharmaStore', 'true')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (2, 'LakarstvaOOD', 'true')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (3, 'Mareshki', 'false')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (4, 'VratsaMedicals', 'false')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (5, 'SofiaPill', 'false')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (6, 'Medcine+', 'true')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (7, 'PlusM', 'true')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (8, 'LocalPharma', 'false')
INSERT [dbo].[Supplier] ([Id], [Name], [IsImporter]) VALUES (9, 'EvtiniLekarstvaEOOD', 'false')

SET IDENTITY_INSERT [dbo].[Supplier] OFF
SET IDENTITY_INSERT [dbo].[Medicines] ON 

INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (1, 'Paracetamol', 100, 2, 2)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (2, 'Benalgin', 20, 23, 2)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (3, 'Menta, Glog i Valerian', 20, 2, 3)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (4, 'Nurofen', 25, 28, 1)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (5, 'Zarontin', 50, 7, 4)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (6, 'Cabozantinib Tablets', 230, 2.5, 5)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (7, 'Cabometyx', 10, 2, 6)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (8, 'Valstar', 2, 2, 7)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (9, 'Ulipristal Acetate Tablet', 1000, 2, 8)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (10, 'Saizen', 54, 2, 9)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (11, 'Valcyte', 60, 2, 9)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (12, 'Fabior', 80, 1, 8)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (13, 'Ibandronate Sodium', 143, 0.2, 7)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (14, 'Santyl', 540, 99, 2)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (15, 'Ultrase MT', 250, 0.99, 1)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (16, 'Welchol', 50, 1.4, 3)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (17, 'Salsalate', 1, 5, 5)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (18, 'Calan', 0, 10, 5)
INSERT [dbo].[Medicines] ([Id], [Name], [Quantity], [Price], [SupplierId]) VALUES (19, 'Factrel', 53, 800, 5)

SET IDENTITY_INSERT [dbo].[Medicines] OFF
SET IDENTITY_INSERT [dbo].[Diagnoses] ON 

INSERT [dbo].[Diagnoses] ([Id], [Name], [Description]) VALUES (1, 'Hrema', 'Teche ti nosa')
INSERT [dbo].[Diagnoses] ([Id], [Name], [Description]) VALUES (2, 'Shum v ushite', 'Imash neshto v ushite')
INSERT [dbo].[Diagnoses] ([Id], [Name], [Description]) VALUES (3, 'Navehnat glezen', 'Leko nakucvane')
INSERT [dbo].[Diagnoses] ([Id], [Name], [Description]) VALUES (4, 'Glavobolie', 'Glavata te boli')

SET IDENTITY_INSERT [dbo].[Diagnoses] OFF

SET IDENTITY_INSERT [dbo].[Patients] ON 

INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (1, 'Stanka', 'Petrova', '1940-12-12', 'ul. Jagodka 8', 'true', '2018-08-20', null, '722f20e4-0b39-4f24-8b3b-179b426f5126', 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (2, 'Lubka', 'Ivanova', '1921-02-08', 'ul. Minzuhar 1', 'false', '2018-01-14', null, '722f20e4-0b39-4f24-8b3b-179b426f5126', 2)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (3, 'Gosho', 'Bucata', '1900-01-01', 'ul. Levski 22', 'true', '2018-08-04', null, '722f20e4-0b39-4f24-8b3b-179b426f5126', 3)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (4, 'Slavcho', 'Peevski', '1950-09-01', 'bul Botev 10', 'false', '2018-08-01', null, '722f20e4-0b39-4f24-8b3b-179b426f5126', 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (5, 'Ulian', 'Gergov', '1935-11-15', 'ul. Kokiche 18', 'true', '2016-09-14', '2016-09-20', '722f20e4-0b39-4f24-8b3b-179b426f5126', 4)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (6, 'Kaspar', 'Duhcheto', '1987-10-18', 'ul. Krairechna 50', 'true', '2000-11-14', '2000-12-01', '722f20e4-0b39-4f24-8b3b-179b426f5126', 1)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (7, 'Rejep', 'Ivedik', '1951-05-29', 'ul. Burzei 33', 'false', '2018-07-31', null, '722f20e4-0b39-4f24-8b3b-179b426f5126', 3)
INSERT [dbo].[Patients] ([Id], [FirstName], [LastName], [BirthDate], [Address], [HasHealthInsurance], [RegistrationDate], [DeregistrationDate], [DoctorId], [DiagnosisId]) 
VALUES (8, 'Rebat', 'Qnic', '1990-04-30', 'ul. Pirin 67', 'true', '2018-08-10', null, '722f20e4-0b39-4f24-8b3b-179b426f5126', 4)

SET IDENTITY_INSERT [dbo].[Patients] OFF

INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,1)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,2)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (3 ,3)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (4 ,4)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,5)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,6)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,7)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,8)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,9)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,18)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (1 ,19)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,1)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,3)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,5)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,10)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,11)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,15)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,18)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (2 ,19)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (3 ,5)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (4 ,15)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (5 ,18)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (6 ,13)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (7 ,8)
INSERT [dbo].[PatientMedicine] ([PatientId], [MedicineId]) VALUES (8 ,9)