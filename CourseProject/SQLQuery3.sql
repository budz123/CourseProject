USE [TermPaper]
GO

UPDATE [dbo].[Reservations] SET [CheckInDate] = <CheckInDate, date,>,[CheckOutDate] = <CheckOutDate, date,>,[RoomID] = <RoomID, int,>,[ReservationStatus] = <ReservationStatus, varchar(255),>,[typePayment] = <typePayment, varchar(255),>,[ClientID] = <ClientID, int,>WHERE <Условия поиска,,>
GO

