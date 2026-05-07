using System.Collections.Generic;

namespace ArkkanLMS.Web.Localization
{
    public class DemoCourse
    {
        public string TitleEn { get; set; } = "";
        public string TitleAr { get; set; } = "";
        public string Instructor { get; set; } = "";
        public string Category { get; set; } = "";
        public string Level { get; set; } = "";
        public double Rating { get; set; }
        public int Reviews { get; set; }
        public int Students { get; set; }
        public double Hours { get; set; }
        public int Lessons { get; set; }
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; }
        public bool Bestseller { get; set; }
        public bool New { get; set; }
        public string Color { get; set; } = "#4f46e5";
        public string Icon { get; set; } = "bi-journal-richtext";
        public string Language { get; set; } = "English";
    }

    public class DemoInstructor
    {
        public string Name { get; set; } = "";
        public string NameAr { get; set; } = "";
        public string TitleEn { get; set; } = "";
        public string TitleAr { get; set; } = "";
        public double Rating { get; set; }
        public int Students { get; set; }
        public int Courses { get; set; }
        public string Initials { get; set; } = "";
        public string Color { get; set; } = "#4f46e5";
    }

    public class DemoTestimonial
    {
        public string Name { get; set; } = "";
        public string Role { get; set; } = "";
        public string RoleAr { get; set; } = "";
        public string TextEn { get; set; } = "";
        public string TextAr { get; set; } = "";
        public string Initials { get; set; } = "";
        public string Color { get; set; } = "#4f46e5";
    }

    public class DemoFaq
    {
        public string QuestionEn { get; set; } = "";
        public string QuestionAr { get; set; } = "";
        public string AnswerEn { get; set; } = "";
        public string AnswerAr { get; set; } = "";
    }

    public static class DemoData
    {
        public static IReadOnlyList<DemoCourse> PopularCourses { get; } = new[]
        {
            new DemoCourse { TitleEn = "Advanced React & Next.js 15 Patterns",  TitleAr = "أنماط متقدّمة في React و Next.js 15", Instructor = "Sara Khalid",       Category = "Web Development", Level = "Advanced",     Rating = 4.9, Reviews = 8421, Students = 42890, Hours = 28.5, Lessons = 142, Price = 79.99m,  OriginalPrice = 199.99m, Bestseller = true,  Color = "#4f46e5", Icon = "bi-code-slash" },
            new DemoCourse { TitleEn = "Machine Learning A–Z with Python",       TitleAr = "تعلّم الآلة من الألف إلى الياء بـ Python", Instructor = "Omar Habib",      Category = "Data Science",    Level = "Intermediate", Rating = 4.8, Reviews = 12934, Students = 78201, Hours = 44.0, Lessons = 320, Price = 99.99m,  OriginalPrice = 249.99m, Bestseller = true,  Color = "#7c3aed", Icon = "bi-cpu" },
            new DemoCourse { TitleEn = "Figma for Product Designers (2026)",    TitleAr = "Figma لمصمّمي المنتجات (2026)",          Instructor = "Layla Younes",     Category = "Design",          Level = "Beginner",     Rating = 4.9, Reviews = 5210, Students = 31204, Hours = 18.2, Lessons = 96,  Price = 0,        OriginalPrice = null,    New = true,         Color = "#fb7185", Icon = "bi-palette" },
            new DemoCourse { TitleEn = "Cloud Architecture on AWS — Pro",        TitleAr = "هندسة السحابة على AWS — احترافي",       Instructor = "Karim Al-Saadi",   Category = "Cloud",           Level = "Advanced",     Rating = 4.7, Reviews = 3104, Students = 18432, Hours = 36.0, Lessons = 188, Price = 129.99m, OriginalPrice = 299.99m, Bestseller = true,  Color = "#0ea5e9", Icon = "bi-cloud" },
            new DemoCourse { TitleEn = "Cybersecurity Fundamentals",             TitleAr = "أساسيات الأمن السيبراني",                Instructor = "Hassan Idris",     Category = "Security",        Level = "Beginner",     Rating = 4.8, Reviews = 6240, Students = 39120, Hours = 22.4, Lessons = 124, Price = 59.99m,  OriginalPrice = 149.99m, Color = "#16a34a", Icon = "bi-shield-lock" },
            new DemoCourse { TitleEn = "Digital Marketing Strategy Masterclass", TitleAr = "ماستركلاس استراتيجية التسويق الرقمي",     Instructor = "Maya Tarek",       Category = "Marketing",       Level = "Intermediate", Rating = 4.7, Reviews = 4012, Students = 26102, Hours = 19.5, Lessons = 102, Price = 49.99m,  OriginalPrice = 129.99m, New = true,        Color = "#f59e0b", Icon = "bi-megaphone" },
            new DemoCourse { TitleEn = "Financial Modeling & Valuation",         TitleAr = "النمذجة المالية والتقييم",               Instructor = "Adam Riley",       Category = "Finance",         Level = "Advanced",     Rating = 4.8, Reviews = 2890, Students = 14820, Hours = 26.8, Lessons = 110, Price = 89.99m,  OriginalPrice = 219.99m, Color = "#0f172a", Icon = "bi-graph-up-arrow" },
            new DemoCourse { TitleEn = "Speak Confident English in 30 Days",      TitleAr = "تحدّث الإنجليزية بثقة في 30 يومًا",      Instructor = "Emma Carter",      Category = "Languages",       Level = "Beginner",     Rating = 4.9, Reviews = 18203, Students = 102340, Hours = 12.0, Lessons = 60,  Price = 29.99m, OriginalPrice = 79.99m, Bestseller = true, Color = "#dc2626", Icon = "bi-chat-quote" },
        };

        public static IReadOnlyList<DemoInstructor> TopInstructors { get; } = new[]
        {
            new DemoInstructor { Name = "Sara Khalid",     NameAr = "سارة خالد",     TitleEn = "Senior Engineer @ Stripe",   TitleAr = "مهندسة أولى في Stripe", Rating = 4.9, Students = 142890, Courses = 14, Initials = "SK", Color = "#4f46e5" },
            new DemoInstructor { Name = "Omar Habib",      NameAr = "عمر حبيب",      TitleEn = "ML Lead @ Google",            TitleAr = "قائد تعلّم الآلة في Google", Rating = 4.8, Students = 218201, Courses = 9,  Initials = "OH", Color = "#7c3aed" },
            new DemoInstructor { Name = "Layla Younes",    NameAr = "ليلى يونس",     TitleEn = "Principal Designer @ Figma",  TitleAr = "مصممة رئيسية في Figma", Rating = 4.9, Students =  91204, Courses = 7,  Initials = "LY", Color = "#fb7185" },
            new DemoInstructor { Name = "Karim Al-Saadi",  NameAr = "كريم السعدي",   TitleEn = "Cloud Architect @ AWS",       TitleAr = "مهندس سحابة في AWS", Rating = 4.7, Students =  68432, Courses = 11, Initials = "KS", Color = "#0ea5e9" },
            new DemoInstructor { Name = "Maya Tarek",      NameAr = "مايا طارق",     TitleEn = "Growth Lead @ HubSpot",       TitleAr = "قائدة نموّ في HubSpot", Rating = 4.7, Students = 126102, Courses = 6,  Initials = "MT", Color = "#f59e0b" },
            new DemoInstructor { Name = "Adam Riley",      NameAr = "آدم رايلي",     TitleEn = "CFA — ex-Goldman Sachs",      TitleAr = "محلل مالي — سابقًا Goldman Sachs", Rating = 4.8, Students = 84820, Courses = 8,  Initials = "AR", Color = "#0f172a" },
        };

        public static IReadOnlyList<DemoTestimonial> Testimonials { get; } = new[]
        {
            new DemoTestimonial { Name = "Noura Al-Mutairi", Role = "Frontend Engineer, Saudi Arabia", RoleAr = "مهندسة واجهات أمامية، السعودية",
                TextEn = "ArkkanLMS gave me the structure to ship production React apps. The Arabic-first UI made it feel like home from day one.",
                TextAr = "أركان أعطتني الهيكل اللازم لإطلاق تطبيقات React احترافية. الواجهة العربية جعلتني أشعر بالألفة منذ اليوم الأول.",
                Initials = "NM", Color = "#4f46e5" },
            new DemoTestimonial { Name = "James Patterson",  Role = "Data Scientist, UK",              RoleAr = "عالم بيانات، المملكة المتحدة",
                TextEn = "The cohort experience plus async lessons hit the sweet spot. I finished the ML track in 9 weeks while working full-time.",
                TextAr = "تجربة المجموعات مع الدروس غير المتزامنة كانت مزيجًا مثاليًا. أنهيت مسار التعلم الآلي في 9 أسابيع وأنا أعمل بدوام كامل.",
                Initials = "JP", Color = "#0ea5e9" },
            new DemoTestimonial { Name = "Reem Al-Qahtani",  Role = "Product Designer, UAE",           RoleAr = "مصمّمة منتجات، الإمارات",
                TextEn = "I love the polished dashboards and the certificates. My LinkedIn profile finally feels complete.",
                TextAr = "أحببت اللوحات المتقنة والشهادات. أصبح ملفي على LinkedIn مكتملًا أخيرًا.",
                Initials = "RQ", Color = "#fb7185" },
            new DemoTestimonial { Name = "Ahmed Bensalem",   Role = "Engineering Manager, Morocco",    RoleAr = "مدير هندسي، المغرب",
                TextEn = "We rolled it out across 4 squads. SSO, audit logs, and admin reports just worked.",
                TextAr = "اعتمدناها في 4 فِرَق. SSO وسجلات التدقيق والتقارير الإدارية عملت بسلاسة.",
                Initials = "AB", Color = "#16a34a" },
            new DemoTestimonial { Name = "Sophie Laurent",   Role = "Marketing Lead, France",          RoleAr = "قائدة تسويق، فرنسا",
                TextEn = "The content library is enormous and the production quality is genuinely premium.",
                TextAr = "مكتبة المحتوى ضخمة وجودة الإنتاج عالية حقًا.",
                Initials = "SL", Color = "#f59e0b" },
            new DemoTestimonial { Name = "Yusuf Demir",      Role = "Backend Engineer, Türkiye",       RoleAr = "مهندس خلفي، تركيا",
                TextEn = "From quizzes to revenue analytics for instructors — they thought of everything.",
                TextAr = "من الاختبارات إلى تحليلات إيرادات المدرّبين — فكّروا في كل شيء.",
                Initials = "YD", Color = "#7c3aed" },
        };

        public static IReadOnlyList<DemoFaq> Faqs { get; } = new[]
        {
            new DemoFaq { QuestionEn = "Can I learn at my own pace?",                 QuestionAr = "هل يمكنني التعلّم وفق وتيرتي الخاصة؟",
                          AnswerEn   = "Yes — most courses are self-paced with lifetime access. Cohort tracks have flexible due dates and recordings.",
                          AnswerAr   = "نعم — معظم الدورات بنظام التعلّم الذاتي مع وصول مدى الحياة، وتُتيح المسارات الجماعية مواعيد مرنة وتسجيلات." },
            new DemoFaq { QuestionEn = "Are certificates recognized by employers?",   QuestionAr = "هل الشهادات معترف بها لدى أصحاب العمل؟",
                          AnswerEn   = "Our certificates are blockchain-verified and accepted by 800+ partner employers across the MENA, EU, and US.",
                          AnswerAr   = "شهاداتنا موثّقة عبر البلوكشين ومعتمدة لدى أكثر من 800 جهة توظيف في الشرق الأوسط وأوروبا وأمريكا." },
            new DemoFaq { QuestionEn = "Do you offer Arabic content?",                QuestionAr = "هل تتوفّر دورات باللغة العربية؟",
                          AnswerEn   = "Yes. ArkkanLMS supports Arabic UI (RTL) and 200+ courses are available in Arabic, with auto-generated subtitles for the rest.",
                          AnswerAr   = "نعم. تدعم أركان الواجهة العربية (RTL) وأكثر من 200 دورة متاحة بالعربية، مع ترجمة تلقائية للبقية." },
            new DemoFaq { QuestionEn = "What's the refund policy?",                   QuestionAr = "ما هي سياسة الاسترداد؟",
                          AnswerEn   = "30-day money-back guarantee, no questions asked, on every paid course.",
                          AnswerAr   = "ضمان استرداد المال خلال 30 يومًا دون أي استفسارات لكل دورة مدفوعة." },
            new DemoFaq { QuestionEn = "Can I become an instructor?",                 QuestionAr = "هل يمكنني أن أصبح مدرّبًا؟",
                          AnswerEn   = "Apply through the trainer onboarding flow. Approved trainers get access to the studio with revenue analytics, quiz builder, and live sessions.",
                          AnswerAr   = "يمكنك التقديم عبر مسار اعتماد المدرّبين، وتحصل بعد القبول على وصول كامل لاستوديو المدرّبين." },
            new DemoFaq { QuestionEn = "Is there an enterprise plan?",                QuestionAr = "هل توجد خطة للمؤسسات؟",
                          AnswerEn   = "Yes — SSO, SCIM, custom seats, audit logs, dedicated success manager, and bespoke learning paths.",
                          AnswerAr   = "نعم — تشمل SSO و SCIM ومقاعد مخصّصة وسجلات تدقيق ومدير نجاح مخصّص ومسارات تعلّم مفصّلة." },
        };

        public class DemoBadge { public string TitleEn = ""; public string TitleAr = ""; public string Icon = "bi-award"; public string Color = "#4f46e5"; public bool Earned; }
        public static IReadOnlyList<DemoBadge> Badges { get; } = new[]
        {
            new DemoBadge { TitleEn = "Quick learner",   TitleAr = "متعلّم سريع",     Icon = "bi-lightning-charge-fill", Color = "#f59e0b", Earned = true  },
            new DemoBadge { TitleEn = "First certificate", TitleAr = "أول شهادة",     Icon = "bi-award-fill",            Color = "#4f46e5", Earned = true  },
            new DemoBadge { TitleEn = "7-day streak",    TitleAr = "سلسلة 7 أيام",    Icon = "bi-fire",                  Color = "#dc2626", Earned = true  },
            new DemoBadge { TitleEn = "Course complete", TitleAr = "إكمال دورة",      Icon = "bi-mortarboard-fill",      Color = "#16a34a", Earned = true  },
            new DemoBadge { TitleEn = "Top 5%",           TitleAr = "أفضل 5%",         Icon = "bi-trophy-fill",          Color = "#7c3aed", Earned = false },
            new DemoBadge { TitleEn = "100 lessons",     TitleAr = "100 درس",         Icon = "bi-stars",                 Color = "#0ea5e9", Earned = false },
        };

        public class DemoActivity { public string Icon = "bi-circle"; public string Color = "#4f46e5"; public string TextEn = ""; public string TextAr = ""; public string TimeEn = ""; public string TimeAr = ""; }
        public static IReadOnlyList<DemoActivity> Activities { get; } = new[]
        {
            new DemoActivity { Icon = "bi-play-circle-fill", Color = "#4f46e5", TextEn = "Watched ‘React Server Components’ in Advanced React",        TextAr = "شاهدت ‘مكوّنات الخادم في React’ ضمن React المتقدّم",        TimeEn = "12 min ago",   TimeAr = "قبل 12 دقيقة" },
            new DemoActivity { Icon = "bi-check2-circle",    Color = "#16a34a", TextEn = "Completed quiz ‘State management basics’ — 92%",             TextAr = "أنجزت اختبار ‘أساسيات إدارة الحالة’ — 92%",                TimeEn = "1 hour ago",   TimeAr = "قبل ساعة" },
            new DemoActivity { Icon = "bi-award-fill",       Color = "#f59e0b", TextEn = "Earned the badge ‘Quick learner’",                            TextAr = "حصلت على شارة ‘متعلّم سريع’",                              TimeEn = "Yesterday",    TimeAr = "أمس" },
            new DemoActivity { Icon = "bi-bookmark-star",    Color = "#7c3aed", TextEn = "Bookmarked ‘Async patterns in TypeScript’",                   TextAr = "حفظت درس ‘الأنماط غير المتزامنة في TypeScript’",          TimeEn = "Yesterday",    TimeAr = "أمس" },
            new DemoActivity { Icon = "bi-people-fill",      Color = "#0ea5e9", TextEn = "Joined the ‘Cloud Pro’ cohort with 24 others",               TextAr = "انضممت إلى مجموعة ‘السحابة الاحترافية’ مع 24 آخرين",       TimeEn = "2 days ago",   TimeAr = "قبل يومين" },
        };

        public class DemoLesson { public string TitleEn = ""; public string TitleAr = ""; public string CourseEn = ""; public string CourseAr = ""; public int Progress; public string Duration = ""; public string Color = "#4f46e5"; public string Icon = "bi-play-circle"; }
        public static IReadOnlyList<DemoLesson> ContinueLessons { get; } = new[]
        {
            new DemoLesson { TitleEn = "Suspense & streaming",        TitleAr = "Suspense والتدفّق",                CourseEn = "Advanced React & Next.js",          CourseAr = "React و Next.js المتقدّم",          Progress = 64, Duration = "12:08", Color = "#4f46e5", Icon = "bi-code-slash" },
            new DemoLesson { TitleEn = "Gradient descent intuition", TitleAr = "حدس الانحدار التدريجي",            CourseEn = "Machine Learning A–Z",              CourseAr = "تعلّم الآلة من الألف إلى الياء",     Progress = 38, Duration = "18:42", Color = "#7c3aed", Icon = "bi-cpu" },
            new DemoLesson { TitleEn = "Component variants",         TitleAr = "متغيّرات المكوّنات",                 CourseEn = "Figma for Product Designers",       CourseAr = "Figma لمصمّمي المنتجات",            Progress = 82, Duration = "08:55", Color = "#fb7185", Icon = "bi-palette" },
        };

        public class DemoNotification { public string Icon = "bi-bell"; public string Color = "#4f46e5"; public string TextEn = ""; public string TextAr = ""; public string TimeEn = ""; public string TimeAr = ""; }
        public static IReadOnlyList<DemoNotification> Notifications { get; } = new[]
        {
            new DemoNotification { Icon = "bi-mortarboard-fill", Color = "#4f46e5", TextEn = "New lesson published in Advanced React", TextAr = "تم نشر درس جديد في React المتقدّم", TimeEn = "5m",  TimeAr = "5د" },
            new DemoNotification { Icon = "bi-chat-dots-fill",   Color = "#16a34a", TextEn = "Sara replied to your discussion post",   TextAr = "ردّت سارة على مشاركتك في النقاش",     TimeEn = "1h",  TimeAr = "1س" },
            new DemoNotification { Icon = "bi-calendar-event",   Color = "#f59e0b", TextEn = "Live session ‘System design Q&A’ at 7 PM", TextAr = "جلسة مباشرة ‘أسئلة هندسة الأنظمة’ في 7م",  TimeEn = "Today", TimeAr = "اليوم" },
            new DemoNotification { Icon = "bi-cash-coin",        Color = "#0ea5e9", TextEn = "Coupon LEARN26 unlocked for 25% off",      TextAr = "تم تفعيل كوبون LEARN26 لخصم 25%",         TimeEn = "2d",  TimeAr = "2ي" },
        };

        public class DemoBooking { public string TitleEn = ""; public string TitleAr = ""; public string TimeEn = ""; public string TimeAr = ""; public string InstructorEn = ""; public string InstructorAr = ""; public string Color = "#4f46e5"; }
        public static IReadOnlyList<DemoBooking> UpcomingClasses { get; } = new[]
        {
            new DemoBooking { TitleEn = "Live: System design Q&A",   TitleAr = "مباشر: أسئلة هندسة الأنظمة",   TimeEn = "Today, 19:00", TimeAr = "اليوم 19:00", InstructorEn = "Sara Khalid",   InstructorAr = "سارة خالد",   Color = "#4f46e5" },
            new DemoBooking { TitleEn = "Cohort: ML project review", TitleAr = "مجموعة: مراجعة مشروع تعلّم الآلة", TimeEn = "Tomorrow, 17:30", TimeAr = "غدًا 17:30", InstructorEn = "Omar Habib",   InstructorAr = "عمر حبيب",     Color = "#7c3aed" },
            new DemoBooking { TitleEn = "Workshop: Figma variants",  TitleAr = "ورشة: متغيّرات Figma",         TimeEn = "Fri, 16:00",   TimeAr = "الجمعة 16:00", InstructorEn = "Layla Younes", InstructorAr = "ليلى يونس",   Color = "#fb7185" },
        };

        public class DemoCertificate { public string CourseEn = ""; public string CourseAr = ""; public string Issued = ""; public string Color = "#4f46e5"; public string Code = ""; }
        public static IReadOnlyList<DemoCertificate> Certificates { get; } = new[]
        {
            new DemoCertificate { CourseEn = "JavaScript Foundations",  CourseAr = "أساسيات JavaScript",        Issued = "Mar 2026", Color = "#4f46e5", Code = "ARK-2026-AX91" },
            new DemoCertificate { CourseEn = "Intro to UX Research",    CourseAr = "مقدمة في أبحاث تجربة المستخدم", Issued = "Feb 2026", Color = "#fb7185", Code = "ARK-2026-UX44" },
            new DemoCertificate { CourseEn = "SQL for Analysts",        CourseAr = "SQL للمحلّلين",              Issued = "Dec 2025", Color = "#0ea5e9", Code = "ARK-2025-SQ77" },
        };

        public class DemoMessage { public string FromEn = ""; public string FromAr = ""; public string PreviewEn = ""; public string PreviewAr = ""; public string TimeEn = ""; public string TimeAr = ""; public string Initials = ""; public string Color = "#4f46e5"; public bool Unread; }
        public static IReadOnlyList<DemoMessage> Messages { get; } = new[]
        {
            new DemoMessage { FromEn = "Sara Khalid",  FromAr = "سارة خالد",  PreviewEn = "Great submission on the React assignment — minor feedback inside.",   PreviewAr = "إجابة ممتازة على واجب React — هناك ملاحظات بسيطة في الداخل.", TimeEn = "12m", TimeAr = "12د", Initials = "SK", Color = "#4f46e5", Unread = true  },
            new DemoMessage { FromEn = "Omar Habib",   FromAr = "عمر حبيب",   PreviewEn = "Reminder: cohort sync at 17:30 tomorrow.",                            PreviewAr = "تذكير: لقاء المجموعة غدًا الساعة 17:30.",                  TimeEn = "1h",  TimeAr = "1س",  Initials = "OH", Color = "#7c3aed", Unread = true  },
            new DemoMessage { FromEn = "Maya Tarek",   FromAr = "مايا طارق",  PreviewEn = "I shared the new SEO checklist — let me know what you think!",      PreviewAr = "شاركت قائمة SEO الجديدة — أنتظر رأيك!",                       TimeEn = "Yesterday", TimeAr = "أمس", Initials = "MT", Color = "#f59e0b", Unread = false },
            new DemoMessage { FromEn = "Karim Al-Saadi", FromAr = "كريم السعدي", PreviewEn = "AWS labs are updated for the new region.",                       PreviewAr = "تم تحديث معامل AWS للمنطقة الجديدة.",                          TimeEn = "2d",  TimeAr = "2ي",  Initials = "KS", Color = "#0ea5e9", Unread = false },
        };

        public class DemoAssignment { public string TitleEn = ""; public string TitleAr = ""; public string CourseEn = ""; public string CourseAr = ""; public string DueEn = ""; public string DueAr = ""; public string Status = ""; public string Color = "#4f46e5"; }
        public static IReadOnlyList<DemoAssignment> Assignments { get; } = new[]
        {
            new DemoAssignment { TitleEn = "Build a hooks library",         TitleAr = "أنشئ مكتبة Hooks",                  CourseEn = "Advanced React & Next.js",     CourseAr = "React و Next.js المتقدّم",     DueEn = "Tomorrow", DueAr = "غدًا",       Status = "in_progress", Color = "#4f46e5" },
            new DemoAssignment { TitleEn = "Logistic regression notebook",  TitleAr = "دفتر الانحدار اللوجستي",            CourseEn = "Machine Learning A–Z",         CourseAr = "تعلّم الآلة من الألف إلى الياء", DueEn = "Fri",      DueAr = "الجمعة",     Status = "submitted",   Color = "#7c3aed" },
            new DemoAssignment { TitleEn = "Mobile prototype review",       TitleAr = "مراجعة نموذج تطبيق جوّال",          CourseEn = "Figma for Product Designers",  CourseAr = "Figma لمصمّمي المنتجات",       DueEn = "Mon",      DueAr = "الإثنين",    Status = "graded",      Color = "#fb7185" },
            new DemoAssignment { TitleEn = "Threat-model your home network", TitleAr = "نمذجة تهديدات شبكتك المنزلية",     CourseEn = "Cybersecurity Fundamentals",   CourseAr = "أساسيات الأمن السيبراني",      DueEn = "Wed",      DueAr = "الأربعاء",   Status = "pending",     Color = "#16a34a" },
        };

        public class DemoEnroll { public string StudentEn = ""; public string StudentAr = ""; public string CourseEn = ""; public string CourseAr = ""; public string TimeEn = ""; public string TimeAr = ""; public string Initials = ""; public string Color = "#4f46e5"; }
        public static IReadOnlyList<DemoEnroll> RecentEnrollments { get; } = new[]
        {
            new DemoEnroll { StudentEn = "Aisha Mansour",  StudentAr = "عائشة منصور",  CourseEn = "Advanced React",          CourseAr = "React المتقدّم",         TimeEn = "2m",  TimeAr = "2د", Initials = "AM", Color = "#4f46e5" },
            new DemoEnroll { StudentEn = "Daniel Park",    StudentAr = "دانيال بارك",  CourseEn = "Machine Learning A–Z",    CourseAr = "تعلّم الآلة من الألف للياء", TimeEn = "11m", TimeAr = "11د", Initials = "DP", Color = "#7c3aed" },
            new DemoEnroll { StudentEn = "Rania Said",     StudentAr = "رانيا سعيد",   CourseEn = "Figma Masterclass",       CourseAr = "ماستركلاس Figma",        TimeEn = "32m", TimeAr = "32د", Initials = "RS", Color = "#fb7185" },
            new DemoEnroll { StudentEn = "Liam Walker",    StudentAr = "ليام ووكر",    CourseEn = "Cloud Architecture Pro",  CourseAr = "هندسة السحابة الاحترافية", TimeEn = "1h",  TimeAr = "1س", Initials = "LW", Color = "#0ea5e9" },
            new DemoEnroll { StudentEn = "Yara Najjar",    StudentAr = "يارا نجار",    CourseEn = "Cybersecurity Basics",    CourseAr = "أساسيات الأمن السيبراني", TimeEn = "2h",  TimeAr = "2س", Initials = "YN", Color = "#16a34a" },
        };

        public class DemoTicket { public string SubjectEn = ""; public string SubjectAr = ""; public string FromEn = ""; public string FromAr = ""; public string Status = ""; public string Severity = ""; public string TimeEn = ""; public string TimeAr = ""; }
        public static IReadOnlyList<DemoTicket> SupportTickets { get; } = new[]
        {
            new DemoTicket { SubjectEn = "Cannot access course content",     SubjectAr = "تعذّر الوصول لمحتوى الدورة",   FromEn = "Hassan I.",   FromAr = "حسن إ.",      Status = "open",       Severity = "high",   TimeEn = "5m",  TimeAr = "5د"  },
            new DemoTicket { SubjectEn = "Refund request — order #44210",     SubjectAr = "طلب استرداد — طلب #44210",      FromEn = "Lina R.",     FromAr = "لينا ر.",     Status = "pending",    Severity = "medium", TimeEn = "32m", TimeAr = "32د" },
            new DemoTicket { SubjectEn = "Certificate name correction",       SubjectAr = "تصحيح الاسم على الشهادة",       FromEn = "Tariq A.",    FromAr = "طارق ع.",     Status = "open",       Severity = "low",    TimeEn = "1h",  TimeAr = "1س"  },
            new DemoTicket { SubjectEn = "Trainer payout question",            SubjectAr = "سؤال حول دفعة المدرّب",         FromEn = "Sara K.",     FromAr = "سارة خ.",     Status = "in_progress",Severity = "medium", TimeEn = "3h",  TimeAr = "3س"  },
        };
    }
}
