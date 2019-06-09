DROP TABLE IF EXISTS TaskManagerDB;

DROP PROCEDURE IF EXISTS SelectAllTasks;

DROP PROCEDURE IF EXISTS RemoveTask;

DROP Procedure IF EXISTS AddTask;

DROP Procedure IF EXISTS UpdateTask;

GO


CREATE TABLE TaskManagerDB (
	Id INT IDENTITY PRIMARY KEY,
	TaskDesc VARCHAR(1000) NOT NULL,
	Status VARCHAR(11) NOT NULL,
	Priority VARCHAR(6) NOT NULL,
	Deadline DATE);
	
GO
	
CREATE PROCEDURE SelectAllTasks
AS
SELECT * FROM TaskManagerDB
GO


CREATE PROCEDURE RemoveTask @Id INT
AS
DELETE FROM TaskManagerDB WHERE @Id = Id
GO


CREATE PROCEDURE AddTask 
	@Desc VARCHAR(1000), 
	@Status VARCHAR(11),
	@Priority VARCHAR(6), 
	@Deadline DATE
AS
INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES(@Desc, @Status, @Priority, @Deadline)
GO



CREATE PROCEDURE UpdateTask 
	@Id INT,
	@Desc VARCHAR(1000), 
	@Status VARCHAR(11), 
	@Priority VARCHAR(6), 
	@Deadline DATE
AS
UPDATE TaskManagerDB
SET TaskDesc = @Desc, 
	Status = @Status,
	Priority = @Priority,
	Deadline = @Deadline
WHERE Id = @Id
GO
  

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Dance in the rain forever and a day', 'In Progress', 'Normal', '2019-07-08');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Sew a sweater for my grandchildren', 'In Progress', 'High', '2019-07-03');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Read the Song of Ice and Fire books', 'New', 'Low');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Lose some belly fat', 'New', 'Normal');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Eat that one tasty kebab with double meat', 'Completed', 'High', GETDATE());

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('Enjoy the sun, the wind, generally, the weather', 'Completed', 'High', GETDATE());

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority, Deadline)
	VALUES('This one is going to be long, very long, I am talking the longest of the longs but not that long. I am not crazy, typing 1000 characters here would take a while, and what if i write 1001? No way, not doing it. However, this should be enough to see how a longer description is displayed', 
	'Completed', 'High', GETDATE());

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly...', 'New', 'High');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly Generated...', 'New', 'High');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly Generated Dummy...', 'New', 'High');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly Generated Dummy data...', 'New', 'High');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly Generated Dummy data fills...', 'New', 'High');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly Generated Dummy data fills the...', 'New', 'High');

INSERT INTO TaskManagerDB(TaskDesc, Status, Priority)
	VALUES('Randomly Generated Dummy data fills the rest...', 'New', 'High');

--Randomly Generated Data


INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla. In','New','High','2018/07/25'),('Aliquam ornare, libero at auctor ullamcorper,','New','Normal','2018/09/28'),('eu eros. Nam consequat dolor vitae dolor. Donec fringilla. Donec feugiat metus sit amet ante.','In Progress','Low','2018/06/08'),('eu nulla at sem molestie sodales. Mauris blandit enim consequat purus.','Completed','High','2018/06/14'),('sit amet, risus. Donec nibh enim, gravida sit amet, dapibus id, blandit at, nisi. Cum sociis natoque penatibus et','Completed','High','2018/11/19'),('eleifend. Cras sed leo. Cras vehicula aliquet','New','Normal','2020/03/17'),('imperdiet dictum','In Progress','Low','2018/12/14'),('Nunc ac sem ut dolor dapibus gravida. Aliquam tincidunt, nunc ac mattis ornare, lectus ante','Completed','Low','2019/08/20'),('erat vitae risus. Duis a mi fringilla mi lacinia mattis.','Completed','Normal','2019/04/29'),('velit eu sem.','New','High','2018/12/31');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis augue, eu tempor erat neque','In Progress','Normal','2020/06/07'),('pede. Cras vulputate velit eu sem. Pellentesque ut ipsum ac mi eleifend egestas. Sed pharetra,','New','Normal','2020/06/07'),('penatibus et magnis dis parturient montes, nascetur ridiculus mus. Aenean eget magna. Suspendisse tristique neque venenatis lacus. Etiam bibendum','In Progress','Low','2019/01/21'),('mi enim, condimentum eget, volutpat ornare, facilisis eget,','Completed','High','2019/04/03'),('gravida sagittis. Duis gravida. Praesent eu nulla at sem molestie sodales. Mauris blandit enim consequat purus. Maecenas','New','Normal','2019/06/28'),('at, nisi. Cum sociis natoque penatibus et magnis dis parturient montes,','Completed','Low','2019/06/16'),('Phasellus','Completed','High','2019/07/12'),('mi eleifend egestas. Sed pharetra,','New','Normal','2020/05/12'),('dapibus id, blandit at, nisi. Cum sociis natoque','New','Normal','2019/04/11'),('vitae purus gravida sagittis. Duis gravida. Praesent eu','In Progress','High','2019/09/14');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('porta elit, a feugiat tellus lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede','In Progress','High','2018/10/07'),('Maecenas ornare egestas ligula. Nullam feugiat placerat velit. Quisque varius. Nam porttitor scelerisque neque. Nullam','In Progress','Low','2020/02/28'),('taciti sociosqu ad litora torquent per','Completed','Normal','2018/10/20'),('Fusce aliquam, enim nec tempus scelerisque, lorem ipsum sodales purus, in molestie tortor nibh sit amet orci. Ut sagittis','Completed','Normal','2019/04/19'),('scelerisque mollis. Phasellus libero mauris, aliquam eu, accumsan sed,','Completed','High','2019/03/24'),('lectus. Cum sociis','In Progress','Low','2020/02/25'),('libero mauris, aliquam','New','Normal','2020/05/29'),('mauris elit, dictum eu, eleifend nec, malesuada ut,','In Progress','High','2019/12/25'),('nec, cursus a, enim. Suspendisse aliquet, sem ut cursus luctus, ipsum leo elementum sem, vitae aliquam eros turpis non','New','Normal','2018/08/05'),('a, arcu. Sed et','In Progress','High','2018/09/05');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('vel, mauris. Integer sem elit, pharetra ut, pharetra sed,','Completed','High','2020/01/08'),('aliquet lobortis,','Completed','Normal','2019/06/21'),('tincidunt, neque vitae semper egestas, urna justo faucibus lectus, a sollicitudin orci','Completed','Normal','2019/03/16'),('non, vestibulum nec, euismod in, dolor. Fusce feugiat. Lorem ipsum dolor sit','Completed','Normal','2019/10/09'),('lectus. Nullam','Completed','Low','2019/11/01'),('Duis elementum, dui quis accumsan convallis, ante lectus convallis est, vitae sodales nisi magna','New','Normal','2020/03/10'),('Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Fusce aliquet magna a neque. Nullam ut','New','High','2019/07/22'),('eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis, lacus pede sagittis','Completed','Normal','2020/01/24'),('nulla at sem molestie sodales. Mauris','In Progress','High','2018/08/15'),('metus urna convallis erat, eget tincidunt dui','Completed','Low','2020/03/29');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('libero et tristique pellentesque, tellus sem mollis dui, in sodales elit erat vitae risus. Duis a mi fringilla','Completed','Normal','2019/07/22'),('ligula consectetuer rhoncus. Nullam velit dui,','Completed','Normal','2019/10/13'),('elementum purus, accumsan interdum libero','Completed','Low','2018/07/27'),('dolor, tempus non, lacinia at, iaculis quis, pede. Praesent eu dui. Cum sociis natoque penatibus et magnis dis parturient','Completed','Low','2019/02/06'),('metus. Aenean sed pede nec','In Progress','Normal','2019/01/24'),('mi. Aliquam gravida mauris ut mi. Duis risus odio,','In Progress','Low','2019/09/18'),('felis orci, adipiscing non, luctus sit amet,','New','Normal','2019/05/16'),('eu enim. Etiam imperdiet dictum magna.','In Progress','Low','2019/07/24'),('quis, tristique ac, eleifend vitae, erat. Vivamus nisi. Mauris nulla. Integer urna. Vivamus molestie dapibus ligula. Aliquam','New','Normal','2020/06/03'),('ullamcorper eu, euismod','In Progress','Normal','2020/01/22');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('Fusce mollis. Duis sit amet diam eu dolor egestas rhoncus. Proin nisl sem, consequat nec, mollis vitae,','In Progress','Low','2019/08/21'),('Vestibulum accumsan neque et nunc.','New','High','2020/01/14'),('Aenean egestas hendrerit neque. In ornare','New','Low','2020/04/17'),('a, auctor non, feugiat nec, diam. Duis mi enim, condimentum eget, volutpat ornare, facilisis','In Progress','Low','2019/05/11'),('libero. Proin mi. Aliquam gravida mauris ut mi. Duis risus odio, auctor vitae, aliquet nec, imperdiet nec, leo. Morbi neque','Completed','High','2018/12/12'),('ridiculus mus. Donec','In Progress','High','2018/11/17'),('blandit viverra. Donec tempus, lorem fringilla','In Progress','High','2019/07/05'),('sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Proin vel nisl. Quisque','In Progress','High','2019/01/21'),('metus. Vivamus euismod urna. Nullam lobortis quam a felis ullamcorper viverra. Maecenas iaculis','New','Low','2018/10/10'),('adipiscing lacus. Ut nec urna et arcu imperdiet ullamcorper. Duis at','Completed','Normal','2020/03/11');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('arcu. Vivamus sit amet risus. Donec egestas. Aliquam nec enim. Nunc ut erat.','New','Low','2019/11/22'),('Nullam','Completed','Normal','2020/05/22'),('facilisis facilisis, magna tellus faucibus leo,','Completed','Normal','2019/09/24'),('convallis, ante lectus convallis est, vitae sodales nisi magna sed dui. Fusce aliquam, enim nec tempus','In Progress','Normal','2020/05/15'),('aliquam iaculis, lacus','Completed','Normal','2019/08/31'),('Donec tempus,','Completed','Low','2019/04/03'),('neque. Nullam ut nisi a odio semper cursus. Integer mollis. Integer tincidunt aliquam arcu. Aliquam ultrices iaculis odio. Nam interdum','New','Normal','2020/02/15'),('leo. Cras vehicula aliquet libero. Integer in magna. Phasellus dolor elit, pellentesque a, facilisis','In Progress','Low','2018/09/27'),('pede. Praesent eu dui. Cum sociis natoque penatibus et magnis dis parturient montes,','Completed','High','2020/03/18'),('Nulla interdum. Curabitur dictum. Phasellus in felis. Nulla','Completed','High','2019/03/21');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('eros non enim commodo hendrerit. Donec porttitor','Completed','Low','2019/05/28'),('Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus.','In Progress','Low','2019/01/16'),('ullamcorper. Duis at lacus. Quisque purus','New','Normal','2018/07/12'),('turpis. Nulla aliquet. Proin velit.','In Progress','Normal','2018/12/28'),('posuere cubilia Curae; Phasellus ornare. Fusce','New','Low','2020/01/24'),('consequat, lectus sit amet luctus','In Progress','High','2019/09/15'),('Morbi quis urna. Nunc quis arcu vel quam dignissim pharetra. Nam ac nulla. In tincidunt congue turpis. In condimentum. Donec','New','Low','2019/11/15'),('tristique pharetra. Quisque ac libero nec ligula consectetuer rhoncus. Nullam velit dui, semper et, lacinia vitae, sodales at, velit. Pellentesque','New','Normal','2019/12/05'),('odio vel est tempor bibendum. Donec felis orci, adipiscing non, luctus','Completed','Normal','2020/03/08'),('lacus. Quisque imperdiet, erat nonummy ultricies ornare, elit elit fermentum risus, at fringilla purus mauris','Completed','High','2019/09/22');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('sed sem egestas','In Progress','Low','2019/02/12'),('lacinia. Sed congue, elit sed consequat auctor, nunc','New','Normal','2019/06/17'),('porttitor scelerisque neque. Nullam nisl. Maecenas malesuada fringilla est. Mauris','New','Low','2019/07/10'),('massa rutrum magna. Cras convallis convallis dolor. Quisque tincidunt pede ac urna. Ut tincidunt vehicula risus.','In Progress','Low','2019/07/30'),('massa. Mauris vestibulum, neque sed dictum eleifend, nunc risus varius orci, in consequat enim diam vel arcu.','In Progress','Low','2019/09/08'),('ullamcorper.','Completed','Normal','2019/03/19'),('consectetuer mauris','Completed','Low','2019/07/07'),('cursus purus. Nullam scelerisque neque sed sem egestas blandit. Nam nulla magna,','New','Low','2018/11/05'),('Phasellus in felis. Nulla tempor augue ac ipsum. Phasellus vitae mauris','In Progress','Low','2018/10/26'),('nisi dictum augue malesuada','Completed','High','2019/10/29');
INSERT INTO TaskManagerDB([TaskDesc],[Status],[Priority],[Deadline]) VALUES('interdum ligula eu enim. Etiam imperdiet dictum magna. Ut tincidunt orci quis lectus. Nullam suscipit, est ac','Completed','Normal','2019/01/20'),('lorem eu metus. In lorem. Donec elementum, lorem ut aliquam iaculis,','Completed','High','2018/12/15'),('Nullam feugiat placerat','In Progress','Normal','2019/10/24'),('fringilla mi lacinia mattis. Integer eu lacus. Quisque imperdiet, erat nonummy ultricies ornare,','In Progress','High','2020/01/12'),('pede, malesuada vel, venenatis vel, faucibus id, libero.','Completed','Normal','2019/05/27'),('accumsan sed, facilisis vitae, orci. Phasellus dapibus quam quis diam. Pellentesque habitant morbi tristique senectus et netus et malesuada','In Progress','High','2020/02/25'),('ornare. Fusce','New','Low','2019/02/26'),('tristique senectus et netus et malesuada fames ac turpis egestas. Fusce aliquet magna a neque. Nullam ut nisi a odio','New','Low','2019/07/23'),('lacus. Mauris non dui nec urna suscipit nonummy. Fusce fermentum fermentum arcu. Vestibulum ante ipsum primis','Completed','Low','2019/09/10'),('pede et risus. Quisque libero','In Progress','Normal','2018/12/16');
