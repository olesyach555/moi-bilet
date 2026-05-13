USE УниверсальноеПриложение;
GO

-- 1. СОЗДАНИЕ ТАБЛИЦЫ ПОЛЬЗОВАТЕЛЕЙ
-- ============================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Пользователи')
BEGIN
    CREATE TABLE dbo.Пользователи (
        ИДентификатор INT PRIMARY KEY IDENTITY(1,1),
        Логин NVARCHAR(100) NOT NULL UNIQUE,
        ПарольХэш NVARCHAR(MAX) NOT NULL,
        Почта NVARCHAR(255) NOT NULL,
        ДатаСоздания DATETIME DEFAULT GETDATE()
    );
END
GO

-- 2. ХРАНИМЫЕ ПРОЦЕДУРЫ ДЛЯ ПОЛЬЗОВАТЕЛЕЙ
-- ============================================================

-- 2.1 Создать пользователя
CREATE OR ALTER PROCEDURE sp_СоздатьПользователя
    @Логин NVARCHAR(100),
    @ПарольХэш NVARCHAR(MAX),
    @Почта NVARCHAR(255),
    @НовыйИД INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM dbo.Пользователи WHERE Логин = @Логин)
        BEGIN
            RAISERROR(N'Пользователь с таким логином уже существует', 16, 1);
            RETURN;
        END;

        INSERT INTO dbo.Пользователи (Логин, ПарольХэш, Почта)
        VALUES (@Логин, @ПарольХэш, @Почта);

        SET @НовыйИД = SCOPE_IDENTITY();
    END TRY
    BEGIN CATCH
        DECLARE @ОшибкаСообщение NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ОшибкаСообщение, 16, 1);
    END CATCH;
END;
GO

-- 2.2 Получить пользователя по логину
CREATE OR ALTER PROCEDURE sp_ПолучитьПользователяПоЛогину
    @Логин NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ИДентификатор, Логин, ПарольХэш, Почта
    FROM dbo.Пользователи
    WHERE Логин = @Логин;
END;
GO

-- 2.3 Обновить пароль
CREATE OR ALTER PROCEDURE sp_ОбновитьПароль
    @ИДентификатор INT,
    @НовыйПарольХэш NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.Пользователи
    SET ПарольХэш = @НовыйПарольХэш
    WHERE ИДентификатор = @ИДентификатор;
END;
GO

-- 3. ДОБАВЛЕНИЕ АДМИНИСТРАТОРА (admin / admin)
-- ============================================================
IF NOT EXISTS (SELECT 1 FROM dbo.Пользователи WHERE Логин = N'admin')
BEGIN
    INSERT INTO dbo.Пользователи (Логин, ПарольХэш, Почта)
    VALUES (N'admin', N'8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918', N'olesyachernovawwork@gmail.com');
END
GO

-- 2.4 Получить пользователя по ИД
CREATE OR ALTER PROCEDURE sp_ПолучитьПользователяПоИД
    @ИДентификатор INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ИДентификатор, Логин, ПарольХэш, Почта
    FROM dbo.Пользователи
    WHERE ИДентификатор = @ИДентификатор;
END;
GO
