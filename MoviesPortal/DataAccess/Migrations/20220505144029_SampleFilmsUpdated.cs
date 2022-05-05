using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class SampleFilmsUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(800)",
                maxLength: 800,
                nullable: false,
                defaultValue: "Nie dodano jeszcze żadnego opisu.",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldDefaultValue: "Nie dodano jeszcze żadnego opisu.");

            migrationBuilder.InsertData(
                table: "CreativePersons",
                columns: new[] { "Id", "DateOfBirth", "Name", "PhotographyPath", "Surname" },
                values: new object[,]
                {
                    { 9, new DateTime(1975, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angelina", "https://drive.google.com/uc?id=1B0uRX19hxh-vuDe66HTjabCeManc4nAs", "Jolie" },
                    { 10, new DateTime(1988, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alicia", "https://drive.google.com/uc?id=1rLzH3Lwzr33LQzR3wo9k8utsxwNszW-A", "Vikander" },
                    { 11, new DateTime(1963, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brad", "https://drive.google.com/uc?id=1mX8nHLgNfessLVmmGJ860azAjJVi1EPq", "Pitt" },
                    { 12, new DateTime(1970, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matt", "https://drive.google.com/uc?id=1l-meYLM_aRFLbNXcUms5Wns6GUOe7ifB", "Damon" },
                    { 13, new DateTime(1961, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "George", "https://drive.google.com/uc?id=1AKoEMsb7lQgDzcuGq2nDsTs360_PcxlI", "Clooney" },
                    { 14, new DateTime(1956, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom", "https://drive.google.com/uc?id=1yuieDlNZnZaZyNiFVLX8Q2z32V7_s_Ta", "Hanks" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "BackgroundPoster", "Description", "ImdbRatio", "IsForKids", "PosterPath", "Release Date", "Title", "TrailerUrl" },
                values: new object[,]
                {
                    { 4, "", "Navy S.E.A.L. sniper Chris Kyle's pinpoint accuracy saves countless lives on the battlefield and turns him into a legend. Back home with his family after four tours of duty, however, Chris finds that it is the war he can't leave behind.", "7.3", false, "https://drive.google.com/uc?id=1ubmorpefQEGcsXbJy97LK107JfYkCZeN", 2014, "American Sniper", "https://www.youtube.com/watch?v=99k3u9ay1gs" },
                    { 5, "", "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart.", "8.8", false, "https://drive.google.com/uc?id=1xwe8zw0aFAqgsaQxi_NQeUTxYLKxFGs2", 1994, "Forrest Gump", "https://www.youtube.com/watch?v=bLvqoHBptjg" },
                    { 6, "", "A grizzled tank commander makes tough decisions as he and his crew fight their way across Germany in April, 1945.", "7.5", false, "https://drive.google.com/uc?id=12wUK79utIGpLTOtnL3l-rMoj-C_Nv1nh", 2014, "Fury", "https://www.imdb.com/video/vi1850190873?playlistId=tt2713180&ref_=tt_ov_vi" },
                    { 7, "", "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.", "8.5", false, "https://drive.google.com/uc?id=1UMAYGciJObSaELHnDNCkYsDPLTJJyosp", 2000, "Gladiator", "https://www.imdb.com/video/vi2628367897?playlistId=tt0172495&ref_=tt_pr_ov_vi" },
                    { 8, "", "A man is picked up by a fishing boat, bullet-riddled and suffering from amnesia, before racing to elude assassins and attempting to regain his memory.", "7.9", false, "https://drive.google.com/uc?id=1SoQC_cnFOZhMFg_u3H2HBEh3pISVBAYb", 2002, "The Bourne Identity", "https://youtu.be/FpKaB5dvQ4g" },
                    { 9, "", "When Jason Bourne is framed for a CIA operation gone awry, he is forced to resume his former life as a trained assassin to survive.", "7.7", false, "https://drive.google.com/uc?id=1xvFGpVTZ8y4RTBbEIJ_CZWwSp3FbhPPS", 2017, "The Bourne Supremacy", "https://www.youtube.com/watch?v=Y-HqyyfBbSo" },
                    { 10, "", "Jason Bourne dodges a ruthless C.I.A. official and his Agents from a new assassination program while searching for the origins of his life as a trained killer.", "8.0", false, "https://drive.google.com/uc?id=1MVVlgzhCRPDAnNsLRXYy46nlHrxbh1pY", 2007, "The Bourne Ultimatum", "https://youtu.be/ZT2ZxjUjSo0" },
                    { 11, "", "The CIA's most dangerous former operative is drawn out of hiding to uncover more explosive truths about his past.", "7.8", false, "https://drive.google.com/uc?id=1sZ_4GFUctmq_VxM63zMImW2LdWTL6k4t", 2016, "Jason Bourne", "https://www.imdb.com/video/vi1805498137?playlistId=tt4196776&ref_=tt_ov_vi" },
                    { 12, "", "Video game adventurer Lara Croft comes to life in a movie where she races against time and villains to recover powerful ancient artifacts.", "5.7", false, "https://drive.google.com/uc?id=1sgLLKO7Glnr9U9enAn7HjdrTAvzNFu9j", 2001, "Lara Croft Tomb Raider", "https://youtu.be/VlCylyAKpGA" },
                    { 13, "", "Adventurer Lara Croft goes on a quest to save the mythical Pandora's Box, before an evil scientist finds it, and recruits a former Marine turned mercenary to assist her.", "5.5", false, "https://drive.google.com/uc?id=1BUuXI7WmOuoY67y-y_7Aqwmv5hU0nzP0", 2003, "Tomb Raider The Cradle of Life", "https://youtu.be/G4bhBabn-wU" },
                    { 14, "", "Lara Croft (Alicia Vikander), the fiercely independent daughter of a missing adventurer, must push herself beyond her limits when she discovers the island where her father, Lord Richard Croft (Dominic West) disappeared.", "6.3", false, "https://drive.google.com/uc?id=1SQcvZrL7kjA7MLGfDBZl2pWaNt92I8fY", 2018, "Tomb Raider", "https://youtu.be/8ndhidEmUbI" },
                    { 15, "", "When a beautiful stranger leads computer hacker Neo to a forbidding underworld, he discovers the shocking truth--the life he knows is the elaborate deception of an evil cyber-intelligence.", "8.7", false, "https://drive.google.com/uc?id=17XIWkf4cwp7LI3Tt8qY2cUp68cymFjqj", 1999, "The Matrix", "https://youtu.be/vKQi3bBA1y8" },
                    { 16, "", "Freedom fighters Neo, Trinity and Morpheus continue to lead the revolt against the Machine Army, unleashing their arsenal of extraordinary skills and weaponry against the systematic forces of repression and exploitation.", "7.2", false, "https://drive.google.com/uc?id=1ojvVyQAwChj5d8aMH6mZ67rxlAR8uTb3", 2003, "The Matrix Reloaded", "https://youtu.be/zmYE3tg26Qc" },
                    { 17, "", "The human city of Zion defends itself against the massive invasion of the machines as Neo fights to end the war at another front while also opposing the rogue Agent Smith.", "6.7", false, "https://drive.google.com/uc?id=1d1jCZlxMP-XLHM7qAYIUkMITnz8B5SbU", 2003, "The Matrix Revolutions", "https://youtu.be/hMbexEPAOQI" },
                    { 18, "", "Return to a world of two realities: one, everyday life; the other, what lies behind it. To find out if his reality is a construct, to truly know himself, Mr. Anderson will have to choose to follow the white rabbit once more.", "5.7", false, "https://drive.google.com/uc?id=1RsRaza_JC5w4_6aPl4vM3QuD-ENk4jUZ", 2021, "The Matrix Resurrections", "https://youtu.be/9ix7TUGVYIo" },
                    { 19, "", "A bored married couple is surprised to learn that they are both assassins hired by competing agencies to kill each other.", "6.5", false, "https://drive.google.com/uc?id=1ZvEDxYPRWweYP2VQGucS1I_TJ-i_HPgn", 2005, "Mr & Mrs Smith", "https://youtu.be/CZ0B22z22pI" },
                    { 20, "", "Danny Ocean and his ten accomplices plan to rob three Las Vegas casinos simultaneously.", "7.7", false, "https://drive.google.com/uc?id=1FW02lDizH6K5Waer9n0EDe_J8bgTIEOO", 2001, "Ocean's Eleven", "https://youtu.be/imm6OR605UI" },
                    { 21, "", "Daniel Ocean recruits one more team member so he can pull off three major European heists in this sequel to Ocean's Eleven (2001).", "6.4", false, "https://drive.google.com/uc?id=1RiCgEjwWMsggk2FCuRC2hTZn1h48B_gT", 2004, "Ocean's Twelve", "https://youtu.be/k9uhRSLMORw" },
                    { 22, "", "Danny Ocean rounds up the boys for a third heist after casino owner Willy Bank double-crosses one of the original eleven, Reuben Tishkoff.", "6.9", false, "https://drive.google.com/uc?id=1Zh3OFLHAh4JXMtfwmaQQQzpm9-L5-S_X", 2007, "Ocean's Thirteen", "https://youtu.be/so9Eh-Guci8" },
                    { 23, "", "Rambo returns to the jungles of Vietnam on a mission to infiltrate an enemy base-camp and rescue the American POWs still held captive there.", "6.5", false, "https://drive.google.com/uc?id=1L-vC9i6dU_ADNykO-OOkWKwKPNc3WuCj", 1985, "Rambo II", "https://youtu.be/WQGJAIYtWD4" },
                    { 24, "", "Rambo mounts a one-man mission to rescue his friend Colonel Trautman from the clutches of the formidable invading Soviet forces in Afghanistan.", "5.8", false, "https://drive.google.com/uc?id=1RrKOIRkqW6klpOQ1G5F-kXonXJip9v00", 1988, "Rambo III", "https://youtu.be/IQt9bDOGTgg" },
                    { 25, "", "The lives of guards on Death Row are affected by one of their charges: a black man accused of child murder and rape, yet who has a mysterious gift.", "8.6", false, "https://drive.google.com/uc?id=1ixqYqYP1cJ8WePqcvEc46uku-dbbwrzp", 1999, "The Green Mile", "https://youtu.be/Ki4haFrqSrw" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CreativePersons",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movies",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "Nie dodano jeszcze żadnego opisu.",
                oldClrType: typeof(string),
                oldType: "nvarchar(800)",
                oldMaxLength: 800,
                oldDefaultValue: "Nie dodano jeszcze żadnego opisu.");
        }
    }
}
