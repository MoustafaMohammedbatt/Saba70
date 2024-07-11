using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Persistence.Helpers
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            if (!context.GueessPlayers.Any())
            {
                var gueessPlayers = new List<GueessPlayer>()
                {
                    new GueessPlayer{Id=1, PlayerName="محمد ابو تريكه ", Hint1="لاعب حريف جداً" ,Hint2="احسن اللاعيبة اللى أنجبتهم الكرة المصرية",Hint3="هداف كاس العالم للانديه 2006",Hint4="هداف دورى ابطال افريقيا 2006" , Hint5="الفنان"},
                    new GueessPlayer{Id=2, PlayerName="ميسي",Hint1="لاعب حريف جداً" ,Hint2="احسن اللاعيبة اللى أنجبتهم الكرة ",Hint3="الهداف التاريخي لمنتخب بلاده",Hint4="اعظم من انجبت كره القدم" , Hint5="البابا"},

                };
                foreach (var gueessPlayer in gueessPlayers)
                {
                    context.GueessPlayers.Add(gueessPlayer);
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.GueessPlayers ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.GueessPlayers OFF;");
                    context.Database.CloseConnection();
                }
            }

            if (!context.PassWords.Any())
            {
                var passWords = new List<PassWord>()
                {
                    new PassWord{Id=1, Name="محمد ابو تريكه ",},
                    new PassWord{Id=2, Name="محمد صلاح ",},
                    new PassWord{Id=3, Name="ميسي ",},
                    new PassWord{Id=4, Name="كريستيانو ",},
                    new PassWord{Id=5, Name="لويس سواريز ",},
                    new PassWord{Id=6, Name="ابراهيموفيتش ",},
                    new PassWord{Id=7, Name="محمد النني  ",},
                    new PassWord{Id=8, Name="نيمار ",},
                    new PassWord{Id=9, Name="كليان مبابي  ",},
                    new PassWord{Id=10, Name="هالاند ",},
                    new PassWord{Id=11, Name="لوكا مودريتش ",},
                    new PassWord{Id=12, Name="مصطفى محمد ",},
                    new PassWord{Id=13, Name="عمر مرموش ",},
                    new PassWord{Id=14, Name="انيستا ",},
                    new PassWord{Id=15, Name="مالديني ",},
                    new PassWord{Id=16, Name="مارادونا ",},
                    new PassWord{Id=17, Name="ايفان راكيتيتش ",},
                    new PassWord{Id=18, Name="ساكا ",},
                    new PassWord{Id=19, Name="رودريجو ",},
                    new PassWord{Id=20, Name="رودري ",},

                };
                foreach (var Player in passWords)
                {
                    context.PassWords.Add(Player);
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.PassWords ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.PassWords OFF;");
                    context.Database.CloseConnection();
                }
            }

            if (!context.Acting.Any())
            {
                var Acting = new List<Acting>()
                {
                    new Acting{Id=1, Name="محمد ابو تريكه ",},
                    new Acting{Id=2, Name="محمد صلاح ",},
                    new Acting{Id=3, Name="ميسي ",},
                    new Acting{Id=4, Name="كريستيانو ",},
                    new Acting{Id=5, Name="لويس سواريز ",},
                    new Acting{Id=6, Name="ابراهيموفيتش ",},
                    new Acting{Id=7, Name="محمد النني  ",},
                    new Acting{Id=8, Name="نيمار ",},
                    new Acting{Id=9, Name="كليان مبابي  ",},
                    new Acting{Id=10, Name="هالاند ",},
                    new Acting{Id=11, Name="لوكا مودريتش ",},
                    new Acting{Id=12, Name="مصطفى محمد ",},
                    new Acting{Id=13, Name="عمر مرموش ",},
                    new Acting{Id=14, Name="انيستا ",},
                    new Acting{Id=15, Name="مالديني ",},
                    new Acting{Id=16, Name="مارادونا ",},
                    new Acting{Id=17, Name="ايفان راكيتيتش ",},
                    new Acting{Id=18, Name="ساكا ",},
                    new Acting{Id=19, Name="رودريجو ",},
                    new Acting{Id=20, Name="رودري ",},

                };
                foreach (var Act in Acting)
                {
                    context.Acting.Add(Act);
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Acting ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Acting OFF;");
                    context.Database.CloseConnection();
                }
            }

            if (!context.Risks.Any())
            {
                var risks = new List<Risk>()
                {
                    new Risk{Id=1, Category="الاهلي",
                        EasyQuestion="من هو مدرب الاهلي",EasyQuestionAnswer="مارسيل كولر",
                        RegularQuestion="اللاعب رقم 8 في النادي الاهلي",RegularQuestionAnswer="اكرم توفيق",
                        MeduimQuestion="رئيس النادي السابق",MeduimQuestionAnswer="محمود طاهر", 
                        HardQuestion="اكبر فوز افريقي للنادي الاهلي كان علي نادي ؟",HardQuestionAnswer="اطلع بره"},

                    new Risk{Id=2, Category="منتخب مصر",
                        EasyQuestion="المدير الفني",EasyQuestionAnswer="حسام حسن",
                        RegularQuestion="اكثر لاعب مشاركه",RegularQuestionAnswer="احمد حسن",
                        MeduimQuestion="كم مره حل المنتخب وصيفا لكاس الامم الافريقيه ",MeduimQuestionAnswer="3",
                        HardQuestion="المدير الفني للمنتخ بعد هيكتور كوبر",HardQuestionAnswer="خافيير اجيري"},

                     new Risk{Id=3, Category="الزمالك",
        EasyQuestion="المدير الفني",EasyQuestionAnswer="جوزيه جوميز",
        RegularQuestion="كم مره حصل الزمالك علي السوبر الافريقي",RegularQuestionAnswer="4",
        MeduimQuestion="من هو هداف الزمالك في جميع البطولات؟",MeduimQuestionAnswer="عبد الحليم علي",
        HardQuestion="من هو اللاعب الذي سجل هدف الفوز في نهائي كأس مصر 2013؟",HardQuestionAnswer="حازم إمام"},

    new Risk{Id=4, Category="برشلونه",
        EasyQuestion="من هو قائد الفريق؟",EasyQuestionAnswer="ليونيل ميسي",
        RegularQuestion="أين يقع ملعب الكامب نو؟",RegularQuestionAnswer="برشلونة، إسبانيا",
        MeduimQuestion="كم مرة فاز برشلونة بدوري أبطال أوروبا؟",MeduimQuestionAnswer="5",
        HardQuestion="من هو اللاعب الذي سجل الهدف الحاسم في نهائي دوري أبطال أوروبا 2009؟",HardQuestionAnswer="صامويل إيتو"},

    new Risk{Id=5, Category="ريال مدريد",
        EasyQuestion="من هو المدرب الحالي؟",EasyQuestionAnswer="كارلو أنشيلوتي",
        RegularQuestion="أين يقع ملعب سانتياغو برنابيو؟",RegularQuestionAnswer="مدريد، إسبانيا",
        MeduimQuestion="كم مرة فاز ريال مدريد بدوري أبطال أوروبا؟",MeduimQuestionAnswer="14",
        HardQuestion="من هو اللاعب الذي سجل ثلاثية في نهائي دوري أبطال أوروبا 2018؟",HardQuestionAnswer="كريستيانو رونالدو"},

    new Risk{Id=6, Category="ليفربول",
        EasyQuestion="من هو المدرب الحالي؟",EasyQuestionAnswer="يورغن كلوب",
        RegularQuestion="أين يقع ملعب أنفيلد؟",RegularQuestionAnswer="ليفربول، إنجلترا",
        MeduimQuestion="كم مرة فاز ليفربول بدوري أبطال أوروبا؟",MeduimQuestionAnswer="6",
        HardQuestion="من هو اللاعب الذي سجل الهدف الوحيد في نهائي دوري أبطال أوروبا 2019؟",HardQuestionAnswer="محمد صلاح"},

    new Risk{Id=7, Category="كريستيانو",
        EasyQuestion="في أي نادٍ يلعب الآن؟",EasyQuestionAnswer="النصر السعودي",
        RegularQuestion="ما هو النادي الذي بدأ فيه مسيرته؟",RegularQuestionAnswer="سبورتينغ لشبونة",
        MeduimQuestion="كم مرة فاز بالكرة الذهبية؟",MeduimQuestionAnswer="5",
        HardQuestion="كم عدد الأهداف التي سجلها في دوري أبطال أوروبا؟",HardQuestionAnswer="134"},

    new Risk{Id=8, Category="محمد صلاح",
        EasyQuestion="في أي نادٍ يلعب الآن؟",EasyQuestionAnswer="ليفربول",
        RegularQuestion="ما هو النادي الذي انتقل منه إلى ليفربول؟",RegularQuestionAnswer="روما",
        MeduimQuestion="كم مرة فاز بجائزة أفضل لاعب في أفريقيا؟",MeduimQuestionAnswer="2",
        HardQuestion="كم عدد الأهداف التي سجلها في موسم 2017-2018 في الدوري الإنجليزي؟",HardQuestionAnswer="32"},

    new Risk{Id=9, Category="كاس العالم",
        EasyQuestion="في أي عام أقيمت أول بطولة لكأس العالم؟",EasyQuestionAnswer="1930",
        RegularQuestion="ما هي الدولة المستضيفة لكأس العالم 2022؟",RegularQuestionAnswer="قطر",
        MeduimQuestion="أي منتخب فاز بأكبر عدد من بطولات كأس العالم؟",MeduimQuestionAnswer="البرازيل",
        HardQuestion="من هو اللاعب الذي سجل أكثر عدد من الأهداف في كأس العالم؟",HardQuestionAnswer="ميروسلاف كلوزه"},

    new Risk{Id=10, Category="ميسي",
        EasyQuestion="في أي نادٍ يلعب الآن؟",EasyQuestionAnswer="إنتر ميامي",
        RegularQuestion="ما هو النادي الذي بدأ فيه مسيرته؟",RegularQuestionAnswer="برشلونة",
        MeduimQuestion="كم مرة فاز بالكرة الذهبية؟",MeduimQuestionAnswer="7",
        HardQuestion="كم عدد الأهداف التي سجلها مع برشلونة؟",HardQuestionAnswer="672"},

    new Risk{Id=11, Category="مانشستر سيتي",
        EasyQuestion="من هو المدرب الحالي؟",EasyQuestionAnswer="بيب جوارديولا",
        RegularQuestion="أين يقع ملعب الاتحاد؟",RegularQuestionAnswer="مانشستر، إنجلترا",
        MeduimQuestion="كم مرة فاز مانشستر سيتي بالدوري الإنجليزي الممتاز؟",MeduimQuestionAnswer="8",
        HardQuestion="من هو الهداف التاريخي لمانشستر سيتي؟",HardQuestionAnswer="سيرجيو أجويرو"},

    new Risk{Id=12, Category="يورجن كلوب",
        EasyQuestion="ما هو النادي الذي يدربه حاليًا؟",EasyQuestionAnswer="ليفربول",
        RegularQuestion="ما هو النادي الذي بدأ فيه مسيرته التدريبية؟",RegularQuestionAnswer="ماينز",
        MeduimQuestion="كم مرة فاز بالدوري الألماني؟",MeduimQuestionAnswer="2",
        HardQuestion="كم مرة فاز بدوري أبطال أوروبا؟",HardQuestionAnswer="1"},

                };
                foreach (var risk in risks)
                {
                    context.Risks.Add(risk);
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Risks ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Risks OFF;");
                    context.Database.CloseConnection();
                }
            }

            if (!context.XOImagesColmns.Any())
            {
                var xOImagesColmns = new List<XOImagesColmns>()
                {
                    new XOImagesColmns{Id=1, ImgSrc="/images/XOImgsCol/71r42LZ+adL.jpg",},
                    new XOImagesColmns{Id=2, ImgSrc="/images/XOImgsCol/980_acmilan.jpg",},
                    new XOImagesColmns{Id=3, ImgSrc="/images/XOImgsCol/Argentina.jfif",},
                    new XOImagesColmns{Id=4, ImgSrc="/images/XOImgsCol/aston-villa-logo-on-transparent-background-free-vector.jpg",},
                    new XOImagesColmns{Id=5, ImgSrc="/images/XOImgsCol/Atletico-Madrid-logo.jpg",},
                    new XOImagesColmns{Id=6, ImgSrc="/images/XOImgsCol/Barcelona.jfif",},
                    new XOImagesColmns{Id=7, ImgSrc="/images/XOImgsCol/Bayer 04 Leverkusen.jfif",},
                    new XOImagesColmns{Id=8, ImgSrc="/images/XOImgsCol/belgium-flag-in-on-white-background-vector-29649405.jpg",},
                    new XOImagesColmns{Id=9, ImgSrc="/images/XOImgsCol/Borussia Dortmund.jfif",},
                    new XOImagesColmns{Id=10, ImgSrc="/images/XOImgsCol/Brazil.jfif",},
                    new XOImagesColmns{Id=11, ImgSrc="/images/XOImgsCol/Croatia.jfif",},
                    new XOImagesColmns{Id=12, ImgSrc="/images/XOImgsCol/d21fb2e331ebade29aed8e153cb7cbad.jpg",},
                    new XOImagesColmns{Id=13, ImgSrc="/images/XOImgsCol/England.jfif",},
                    new XOImagesColmns{Id=14, ImgSrc="/images/XOImgsCol/everton-football-club4785.jpg",},
                    new XOImagesColmns{Id=15, ImgSrc="/images/XOImgsCol/France.jfif",},
                    new XOImagesColmns{Id=16, ImgSrc="/images/XOImgsCol/Germany.jfif",},
                    new XOImagesColmns{Id=17, ImgSrc="/images/XOImgsCol/Man City.jfif",},
                    new XOImagesColmns{Id=18, ImgSrc="/images/XOImgsCol/Napoli.jfif",},
                    new XOImagesColmns{Id=19, ImgSrc="/images/XOImgsCol/Netherlands.jfif",},
                    new XOImagesColmns{Id=20, ImgSrc="/images/XOImgsCol/Spain.jfif",},
                    new XOImagesColmns{Id=21, ImgSrc="/images/XOImgsCol/Tottenham.jfif",},

                };
                foreach (var xocol in xOImagesColmns)
                {
                    context.XOImagesColmns.Add(xocol);
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.XOImagesColmns ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.XOImagesColmns OFF;");
                    context.Database.CloseConnection();
                }
            }

            if (!context.XOImagesRows.Any())
            {
                var xOImagesRows = new List<XOImagesRows>()
                {
                    new XOImagesRows{Id=1, ImgSrc="/images/XOImgsRow/20178.png",},
                    new XOImagesRows{Id=2, ImgSrc="/images/XOImgsRow/46a27f96e154a5d64bdf06747c534fa6.jpg",},
                    new XOImagesRows{Id=3, ImgSrc="/images/XOImgsRow/94-949657_jose-mourinho-transparent-background-image-andre-silva-fifa.png",},
                    new XOImagesRows{Id=4, ImgSrc="/images/XOImgsRow/Arsenal.jpg",},
                    new XOImagesRows{Id=5, ImgSrc="/images/XOImgsRow/AS Roma.jfif",},
                    new XOImagesRows{Id=6, ImgSrc="/images/XOImgsRow/Bayern Munich.jfif",},
                    new XOImagesRows{Id=7, ImgSrc="/images/XOImgsRow/Benfica.jfif",},
                    new XOImagesRows{Id=8, ImgSrc="/images/XOImgsRow/Intermilan.jfif",},
                    new XOImagesRows{Id=9, ImgSrc="/images/XOImgsRow/Juventus.jfif",},
                    new XOImagesRows{Id=10, ImgSrc="/images/XOImgsRow/Liverpool.jpg",},
                    new XOImagesRows{Id=11, ImgSrc="/images/XOImgsRow/Lyonnais.jfif",},
                    new XOImagesRows{Id=12, ImgSrc="/images/XOImgsRow/manU.png",},
                    new XOImagesRows{Id=13, ImgSrc="/images/XOImgsRow/Newcastle.jfif",},
                    new XOImagesRows{Id=14, ImgSrc="/images/XOImgsRow/Paric Sanit Germain f.c..jpg",},
                    new XOImagesRows{Id=15, ImgSrc="/images/XOImgsRow/pep-guardiola-manchester-city-manager-face-mask-product-image.jpg",},
                    new XOImagesRows{Id=16, ImgSrc="/images/XOImgsRow/porto.jfif",},
                    new XOImagesRows{Id=17, ImgSrc="/images/XOImgsRow/Real Madrid.jfif",},



                };
                foreach (var xorow in xOImagesRows)
                {
                    context.XOImagesRows.Add(xorow);
                    context.Database.OpenConnection();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.XOImagesRows ON;");
                    context.SaveChanges();
                    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.XOImagesRows OFF;");
                    context.Database.CloseConnection();
                }
            }

        }
    }
}
