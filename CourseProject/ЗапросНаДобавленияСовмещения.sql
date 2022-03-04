

select Reservations.ReservationsID,Reservations.CheckInDate,Reservations.CheckOutDate,Rooms.RoomsID,Reservations.ReservationStatus,Reservations.typePayment,Clients.ClientsID 
from Reservations left join Rooms on  Rooms.RoomsID = Reservations.ReservationsID
left join Clients on Clients.ClientsID = Reservations.ReservationsID




SELECT Reservations.ReservationsID, Reservations.CheckInDate,Reservations.CheckOutDate,Reservations.ReservationStatus,Reservations.typePayment,Rooms.Number,Clients.[Name],Clients.LastName FROM Reservations
left join Rooms on Rooms.RoomsID = Reservations.ReservationsID
left join Clients on Clients.ClientsID = Reservations.ReservationsID



INSERT INTO[dbo].[Reservations] ([CheckInDate],[CheckOutDate],[RoomID],[ReservationStatus],[typePayment],[ClientID])VALUES('2003-10-10','2003-11-11',3,'Reserv','VISA',1)
SELECT Reservations.ReservationsID, Reservations.CheckInDate,Reservations.CheckOutDate,Reservations.ReservationStatus,Reservations.typePayment,Rooms.Number,Clients.[Name],Clients.LastName FROM Reservations
left join Rooms on Rooms.RoomsID = Reservations.RoomID
left join Clients on Clients.ClientsID = Reservations.ClientID
SELECT * from Reservations
