using System.Collections.Generic;

namespace ArkkanLMS.Web.Localization
{
    /// <summary>
    /// Central translation dictionary. Add keys here in both English and Arabic.
    /// Keep keys descriptive and grouped by area (nav.*, dash.*, course.*, ...).
    /// </summary>
    public static class Strings
    {
        public const string DefaultCulture = "en";
        public static readonly string[] SupportedCultures = { "en", "ar" };

        public static IReadOnlyDictionary<string, IReadOnlyDictionary<string, string>> Translations { get; }
            = new Dictionary<string, IReadOnlyDictionary<string, string>>
        {
            // --- Brand / generic ---
            ["brand.name"]              = new Dictionary<string, string> { ["en"] = "ArkkanLMS",                                ["ar"] = "أركان للتعلم" },
            ["brand.tagline"]           = new Dictionary<string, string> { ["en"] = "Elegant learning experiences",             ["ar"] = "تجارب تعلّم أنيقة" },
            ["common.demo"]             = new Dictionary<string, string> { ["en"] = "Demo",                                     ["ar"] = "عرض" },
            ["common.search"]           = new Dictionary<string, string> { ["en"] = "Search",                                   ["ar"] = "بحث" },
            ["common.searchPlaceholder"]= new Dictionary<string, string> { ["en"] = "Search courses, lessons…",                 ["ar"] = "ابحث في الدورات والدروس..." },
            ["common.loading"]          = new Dictionary<string, string> { ["en"] = "Loading…",                                 ["ar"] = "جاري التحميل..." },
            ["common.signedInAs"]       = new Dictionary<string, string> { ["en"] = "Signed in as",                             ["ar"] = "مسجّل الدخول باسم" },
            ["common.noUser"]           = new Dictionary<string, string> { ["en"] = "No user selected",                         ["ar"] = "لم يتم اختيار مستخدم" },
            ["common.viewAll"]          = new Dictionary<string, string> { ["en"] = "View all",                                 ["ar"] = "عرض الكل" },
            ["common.continue"]         = new Dictionary<string, string> { ["en"] = "Continue",                                 ["ar"] = "متابعة" },
            ["common.notifications"]    = new Dictionary<string, string> { ["en"] = "Notifications",                            ["ar"] = "الإشعارات" },
            ["common.preferences"]      = new Dictionary<string, string> { ["en"] = "Preferences",                              ["ar"] = "التفضيلات" },
            ["common.languageEN"]       = new Dictionary<string, string> { ["en"] = "English",                                  ["ar"] = "الإنجليزية" },
            ["common.languageAR"]       = new Dictionary<string, string> { ["en"] = "العربية",                                  ["ar"] = "العربية" },
            ["common.theme"]            = new Dictionary<string, string> { ["en"] = "Theme",                                    ["ar"] = "المظهر" },
            ["common.themeLight"]       = new Dictionary<string, string> { ["en"] = "Light",                                    ["ar"] = "فاتح" },
            ["common.themeDark"]        = new Dictionary<string, string> { ["en"] = "Dark",                                     ["ar"] = "داكن" },

            // --- Navigation (public) ---
            ["nav.home"]                = new Dictionary<string, string> { ["en"] = "Home",                                     ["ar"] = "الرئيسية" },
            ["nav.pricing"]             = new Dictionary<string, string> { ["en"] = "Pricing",                                  ["ar"] = "الأسعار" },
            ["nav.about"]               = new Dictionary<string, string> { ["en"] = "About",                                    ["ar"] = "من نحن" },
            ["nav.courses"]             = new Dictionary<string, string> { ["en"] = "Courses",                                  ["ar"] = "الدورات" },
            ["nav.contact"]             = new Dictionary<string, string> { ["en"] = "Contact",                                  ["ar"] = "تواصل معنا" },
            ["nav.faq"]                 = new Dictionary<string, string> { ["en"] = "FAQ",                                      ["ar"] = "الأسئلة الشائعة" },
            ["nav.login"]               = new Dictionary<string, string> { ["en"] = "Log in",                                   ["ar"] = "تسجيل الدخول" },
            ["nav.register"]            = new Dictionary<string, string> { ["en"] = "Register",                                 ["ar"] = "إنشاء حساب" },
            ["nav.logout"]              = new Dictionary<string, string> { ["en"] = "Logout",                                   ["ar"] = "تسجيل الخروج" },
            ["nav.workspace"]           = new Dictionary<string, string> { ["en"] = "Workspace",                                ["ar"] = "مساحة العمل" },

            // --- Sidebar (student) ---
            ["sb.student.heading"]      = new Dictionary<string, string> { ["en"] = "Student",                                  ["ar"] = "الطالب" },
            ["sb.dashboard"]            = new Dictionary<string, string> { ["en"] = "Dashboard",                                ["ar"] = "لوحة التحكم" },
            ["sb.myCourses"]            = new Dictionary<string, string> { ["en"] = "My Courses",                               ["ar"] = "دوراتي" },
            ["sb.continueLearning"]     = new Dictionary<string, string> { ["en"] = "Continue Learning",                        ["ar"] = "متابعة التعلّم" },
            ["sb.certificates"]         = new Dictionary<string, string> { ["en"] = "Certificates",                             ["ar"] = "الشهادات" },
            ["sb.assignments"]          = new Dictionary<string, string> { ["en"] = "Assignments",                              ["ar"] = "الواجبات" },
            ["sb.calendar"]             = new Dictionary<string, string> { ["en"] = "Calendar",                                 ["ar"] = "التقويم" },
            ["sb.messages"]             = new Dictionary<string, string> { ["en"] = "Messages",                                 ["ar"] = "الرسائل" },
            ["sb.wishlist"]             = new Dictionary<string, string> { ["en"] = "Wishlist",                                 ["ar"] = "قائمة الرغبات" },
            ["sb.settings"]             = new Dictionary<string, string> { ["en"] = "Settings",                                 ["ar"] = "الإعدادات" },
            ["sb.bookings"]             = new Dictionary<string, string> { ["en"] = "My bookings",                              ["ar"] = "حجوزاتي" },
            ["sb.browse"]               = new Dictionary<string, string> { ["en"] = "Browse courses",                           ["ar"] = "استعراض الدورات" },

            // --- Sidebar (trainer) ---
            ["sb.trainer.heading"]      = new Dictionary<string, string> { ["en"] = "Trainer",                                  ["ar"] = "المدرّب" },
            ["sb.analytics"]            = new Dictionary<string, string> { ["en"] = "Analytics",                                ["ar"] = "التحليلات" },
            ["sb.students"]             = new Dictionary<string, string> { ["en"] = "Students",                                 ["ar"] = "الطلاب" },
            ["sb.revenue"]              = new Dictionary<string, string> { ["en"] = "Revenue",                                  ["ar"] = "الإيرادات" },
            ["sb.reviews"]              = new Dictionary<string, string> { ["en"] = "Reviews",                                  ["ar"] = "التقييمات" },
            ["sb.liveSessions"]         = new Dictionary<string, string> { ["en"] = "Live Sessions",                            ["ar"] = "الجلسات المباشرة" },
            ["sb.builder"]              = new Dictionary<string, string> { ["en"] = "Course Builder",                           ["ar"] = "بناء الدورة" },
            ["sb.sessions"]             = new Dictionary<string, string> { ["en"] = "Sessions",                                 ["ar"] = "الجلسات" },
            ["sb.createCourse"]         = new Dictionary<string, string> { ["en"] = "Create course",                            ["ar"] = "إنشاء دورة" },

            // --- Sidebar (admin) ---
            ["sb.admin.heading"]        = new Dictionary<string, string> { ["en"] = "Platform",                                 ["ar"] = "المنصّة" },
            ["sb.overview"]             = new Dictionary<string, string> { ["en"] = "Platform Overview",                        ["ar"] = "نظرة عامة" },
            ["sb.users"]                = new Dictionary<string, string> { ["en"] = "User Management",                          ["ar"] = "إدارة المستخدمين" },
            ["sb.trainerApprovals"]     = new Dictionary<string, string> { ["en"] = "Trainer Approvals",                        ["ar"] = "اعتماد المدرّبين" },
            ["sb.moderation"]           = new Dictionary<string, string> { ["en"] = "Course Moderation",                        ["ar"] = "إدارة الدورات" },
            ["sb.categories"]           = new Dictionary<string, string> { ["en"] = "Categories",                               ["ar"] = "الفئات" },
            ["sb.payments"]             = new Dictionary<string, string> { ["en"] = "Payments",                                 ["ar"] = "المدفوعات" },
            ["sb.reports"]              = new Dictionary<string, string> { ["en"] = "Reports",                                  ["ar"] = "التقارير" },
            ["sb.security"]             = new Dictionary<string, string> { ["en"] = "Security",                                 ["ar"] = "الأمان" },
            ["sb.coupons"]              = new Dictionary<string, string> { ["en"] = "Coupons",                                  ["ar"] = "الكوبونات" },
            ["sb.cms"]                  = new Dictionary<string, string> { ["en"] = "CMS",                                      ["ar"] = "إدارة المحتوى" },
            ["sb.revenueAnalytics"]     = new Dictionary<string, string> { ["en"] = "Revenue analytics",                        ["ar"] = "تحليلات الإيرادات" },

            // --- Landing page ---
            ["land.eyebrow"]            = new Dictionary<string, string> { ["en"] = "Modern training for every role",           ["ar"] = "تدريب عصري لكل الأدوار" },
            ["land.heroTitle"]          = new Dictionary<string, string> { ["en"] = "Master in-demand skills with world-class instructors.", ["ar"] = "أتقن المهارات الأكثر طلبًا مع نخبة من المدرّبين." },
            ["land.heroSubtitle"]       = new Dictionary<string, string> { ["en"] = "Browse 1,200+ courses, attend live sessions, earn verifiable certificates, and stay productive on any device.", ["ar"] = "استعرض أكثر من 1200 دورة، احضر جلسات مباشرة، احصل على شهادات معتمدة، وتعلّم من أي جهاز." },
            ["land.cta.browse"]         = new Dictionary<string, string> { ["en"] = "Browse Courses",                            ["ar"] = "تصفّح الدورات" },
            ["land.cta.dashboard"]      = new Dictionary<string, string> { ["en"] = "Go to dashboard",                          ["ar"] = "الذهاب إلى لوحة التحكم" },
            ["land.cta.start"]          = new Dictionary<string, string> { ["en"] = "Start free trial",                         ["ar"] = "ابدأ النسخة التجريبية مجانًا" },
            ["land.cta.watch"]          = new Dictionary<string, string> { ["en"] = "Watch demo",                                ["ar"] = "شاهد العرض" },

            ["land.stats.learners"]     = new Dictionary<string, string> { ["en"] = "Active learners",                          ["ar"] = "متعلّم نشط" },
            ["land.stats.courses"]      = new Dictionary<string, string> { ["en"] = "Curated courses",                          ["ar"] = "دورة منتقاة" },
            ["land.stats.instructors"]  = new Dictionary<string, string> { ["en"] = "Expert instructors",                       ["ar"] = "مدرّب خبير" },
            ["land.stats.satisfaction"] = new Dictionary<string, string> { ["en"] = "Average rating",                           ["ar"] = "متوسط التقييم" },

            ["land.features.title"]     = new Dictionary<string, string> { ["en"] = "Everything you need to learn faster",      ["ar"] = "كل ما تحتاجه للتعلّم بشكل أسرع" },
            ["land.features.subtitle"]  = new Dictionary<string, string> { ["en"] = "An end-to-end platform built for students, trainers, and institutions.", ["ar"] = "منصة متكاملة مصمّمة للطلاب والمدرّبين والمؤسسات." },
            ["land.feature.adaptive"]   = new Dictionary<string, string> { ["en"] = "Adaptive learning paths",                  ["ar"] = "مسارات تعلّم تكيّفية" },
            ["land.feature.adaptiveDesc"]= new Dictionary<string, string>{ ["en"] = "AI-curated tracks adapt to your pace, gaps, and goals every session.", ["ar"] = "مسارات يقترحها الذكاء الاصطناعي تتكيّف مع وتيرتك وأهدافك." },
            ["land.feature.live"]       = new Dictionary<string, string> { ["en"] = "Live & async classes",                     ["ar"] = "صفوف مباشرة وغير متزامنة" },
            ["land.feature.liveDesc"]   = new Dictionary<string, string> { ["en"] = "Join cohort sessions or watch on demand — every lesson is captioned and indexed.", ["ar"] = "انضم إلى الحصص الجماعية أو شاهدها لاحقًا — كل درس مفهرس ومترجم." },
            ["land.feature.certs"]      = new Dictionary<string, string> { ["en"] = "Verifiable certificates",                  ["ar"] = "شهادات قابلة للتحقّق" },
            ["land.feature.certsDesc"]  = new Dictionary<string, string> { ["en"] = "Blockchain-anchored credentials accepted by 800+ employers worldwide.", ["ar"] = "شهادات معتمدة لدى أكثر من 800 جهة توظيف حول العالم." },
            ["land.feature.studio"]     = new Dictionary<string, string> { ["en"] = "Creator studio",                           ["ar"] = "استوديو المدرّبين" },
            ["land.feature.studioDesc"] = new Dictionary<string, string> { ["en"] = "Drag-and-drop curriculum, quiz builder, video uploads, and revenue analytics.", ["ar"] = "بناء منهج بالسحب والإفلات، صانع اختبارات، تحليلات إيرادات." },
            ["land.feature.community"]  = new Dictionary<string, string> { ["en"] = "Community & cohorts",                      ["ar"] = "مجتمع ومجموعات تعلّم" },
            ["land.feature.communityDesc"]=new Dictionary<string,string> { ["en"] = "Discussion forums, peer reviews, and study groups in every course.",       ["ar"] = "منتديات نقاش، مراجعات الزملاء، ومجموعات دراسة." },
            ["land.feature.enterprise"] = new Dictionary<string, string> { ["en"] = "Enterprise ready",                         ["ar"] = "جاهز للمؤسسات" },
            ["land.feature.enterpriseDesc"]=new Dictionary<string,string>{ ["en"] = "SSO, SCIM, audit logs, role-based access, and dedicated success managers.", ["ar"] = "تسجيل دخول موحّد، سجلات تدقيق، صلاحيات، ومدراء نجاح مخصّصون." },

            ["land.popular.title"]      = new Dictionary<string, string> { ["en"] = "Popular courses this month",               ["ar"] = "الدورات الأكثر رواجًا هذا الشهر" },
            ["land.popular.subtitle"]   = new Dictionary<string, string> { ["en"] = "Hand-picked by our learning team across the most in-demand domains.", ["ar"] = "اختيارات فريقنا التعليمي من أكثر المجالات طلبًا." },

            ["land.instructors.title"]  = new Dictionary<string, string> { ["en"] = "Learn from top instructors",               ["ar"] = "تعلّم من أفضل المدرّبين" },
            ["land.instructors.subtitle"]=new Dictionary<string,string>  { ["en"] = "Industry leaders, published authors, and Google/Meta/Stripe alumni.",   ["ar"] = "خبراء صناعة وقادة من أبرز شركات التقنية." },

            ["land.testimonials.title"] = new Dictionary<string, string> { ["en"] = "Loved by 240,000+ learners",               ["ar"] = "يحبّها أكثر من 240,000 متعلّم" },
            ["land.testimonials.subtitle"]=new Dictionary<string,string> { ["en"] = "Real reviews from real students and teams using ArkkanLMS daily.",     ["ar"] = "آراء حقيقية لطلاب وفِرَق يستخدمون أركان يوميًا." },

            ["land.pricing.title"]      = new Dictionary<string, string> { ["en"] = "Plans for every learner",                  ["ar"] = "باقات تناسب الجميع" },
            ["land.pricing.subtitle"]   = new Dictionary<string, string> { ["en"] = "Start free. Upgrade anytime. Cancel anytime.",["ar"] = "ابدأ مجانًا. ارقِ متى شئت. ألغِ متى شئت." },
            ["land.pricing.monthly"]    = new Dictionary<string, string> { ["en"] = "/month",                                   ["ar"] = "/شهريًا" },
            ["land.pricing.choose"]     = new Dictionary<string, string> { ["en"] = "Choose plan",                              ["ar"] = "اختر الباقة" },
            ["land.pricing.popular"]    = new Dictionary<string, string> { ["en"] = "Most popular",                             ["ar"] = "الأكثر شعبية" },

            ["land.faq.title"]          = new Dictionary<string, string> { ["en"] = "Frequently asked questions",               ["ar"] = "الأسئلة الشائعة" },

            ["land.cta.bigTitle"]       = new Dictionary<string, string> { ["en"] = "Ready to build the next chapter of your career?", ["ar"] = "هل أنت جاهز لكتابة الفصل التالي من مسيرتك؟" },
            ["land.cta.bigSubtitle"]    = new Dictionary<string, string> { ["en"] = "Join 240,000 learners already growing on ArkkanLMS.", ["ar"] = "انضم إلى 240,000 متعلّم ينمون على منصة أركان." },

            // --- Student dashboard ---
            ["dash.welcome"]            = new Dictionary<string, string> { ["en"] = "Welcome back",                             ["ar"] = "أهلًا بعودتك" },
            ["dash.subtitle"]           = new Dictionary<string, string> { ["en"] = "Here's your learning progress and upcoming sessions.", ["ar"] = "هذا ملخّص تقدّمك وجلساتك القادمة." },
            ["dash.streak"]             = new Dictionary<string, string> { ["en"] = "Streak",                                   ["ar"] = "سلسلة الإنجاز" },
            ["dash.kpi.enrolled"]       = new Dictionary<string, string> { ["en"] = "Enrolled courses",                         ["ar"] = "الدورات المسجّلة" },
            ["dash.kpi.completed"]      = new Dictionary<string, string> { ["en"] = "Lessons completed",                        ["ar"] = "الدروس المنجزة" },
            ["dash.kpi.certificates"]   = new Dictionary<string, string> { ["en"] = "Certificates earned",                      ["ar"] = "الشهادات المكتسبة" },
            ["dash.kpi.studyTime"]      = new Dictionary<string, string> { ["en"] = "Study time this week",                     ["ar"] = "وقت الدراسة هذا الأسبوع" },
            ["dash.weeklyProgress"]     = new Dictionary<string, string> { ["en"] = "Weekly progress",                          ["ar"] = "التقدّم الأسبوعي" },
            ["dash.weeklyGoal"]         = new Dictionary<string, string> { ["en"] = "Weekly goal",                              ["ar"] = "الهدف الأسبوعي" },
            ["dash.weeklyGoalSub"]      = new Dictionary<string, string> { ["en"] = "lessons completed of goal",                ["ar"] = "درس من الهدف" },
            ["dash.upcoming"]           = new Dictionary<string, string> { ["en"] = "Upcoming classes",                         ["ar"] = "الجلسات القادمة" },
            ["dash.continueLearning"]   = new Dictionary<string, string> { ["en"] = "Continue learning",                        ["ar"] = "متابعة التعلّم" },
            ["dash.activity"]           = new Dictionary<string, string> { ["en"] = "Activity timeline",                        ["ar"] = "سجل النشاط" },
            ["dash.badges"]             = new Dictionary<string, string> { ["en"] = "Achievement badges",                       ["ar"] = "شارات الإنجاز" },
            ["dash.recommendations"]    = new Dictionary<string, string> { ["en"] = "Recommended for you",                      ["ar"] = "موصى به لك" },
            ["dash.recentLessons"]      = new Dictionary<string, string> { ["en"] = "Recent lessons",                           ["ar"] = "أحدث الدروس" },
            ["dash.notifications"]      = new Dictionary<string, string> { ["en"] = "Notifications",                            ["ar"] = "الإشعارات" },

            // --- Trainer dashboard ---
            ["trainer.title"]           = new Dictionary<string, string> { ["en"] = "Creator studio",                           ["ar"] = "استوديو المدرّب" },
            ["trainer.subtitle"]        = new Dictionary<string, string> { ["en"] = "Track revenue, engagement, and outcomes across your catalog.", ["ar"] = "تابع الإيرادات والتفاعل والنتائج لدوراتك." },
            ["trainer.kpi.revenue"]     = new Dictionary<string, string> { ["en"] = "Revenue (30d)",                            ["ar"] = "الإيرادات (30 يوم)" },
            ["trainer.kpi.students"]    = new Dictionary<string, string> { ["en"] = "Active students",                          ["ar"] = "الطلاب النشطون" },
            ["trainer.kpi.completion"]  = new Dictionary<string, string> { ["en"] = "Avg. completion",                          ["ar"] = "متوسط الإكمال" },
            ["trainer.kpi.rating"]      = new Dictionary<string, string> { ["en"] = "Rating",                                   ["ar"] = "التقييم" },
            ["trainer.revenueChart"]    = new Dictionary<string, string> { ["en"] = "Revenue trend",                            ["ar"] = "اتجاه الإيرادات" },
            ["trainer.coursePerf"]      = new Dictionary<string, string> { ["en"] = "Course performance",                       ["ar"] = "أداء الدورات" },
            ["trainer.studentGrowth"]   = new Dictionary<string, string> { ["en"] = "Student growth",                           ["ar"] = "نموّ الطلاب" },
            ["trainer.engagement"]      = new Dictionary<string, string> { ["en"] = "Engagement",                               ["ar"] = "التفاعل" },
            ["trainer.recentEnroll"]    = new Dictionary<string, string> { ["en"] = "Recent enrollments",                       ["ar"] = "أحدث التسجيلات" },
            ["trainer.pendingReviews"]  = new Dictionary<string, string> { ["en"] = "Pending reviews",                          ["ar"] = "تقييمات بانتظار الرد" },

            // --- Admin dashboard ---
            ["admin.title"]             = new Dictionary<string, string> { ["en"] = "Platform overview",                        ["ar"] = "نظرة عامة على المنصّة" },
            ["admin.subtitle"]          = new Dictionary<string, string> { ["en"] = "Monitor platform health, revenue, and moderation signals.", ["ar"] = "راقب صحة المنصة والإيرادات وإشارات الإشراف." },
            ["admin.kpi.users"]         = new Dictionary<string, string> { ["en"] = "Total users",                              ["ar"] = "إجمالي المستخدمين" },
            ["admin.kpi.active"]        = new Dictionary<string, string> { ["en"] = "Active (30d)",                             ["ar"] = "النشطون (30 يوم)" },
            ["admin.kpi.revenue"]       = new Dictionary<string, string> { ["en"] = "Platform revenue",                         ["ar"] = "إيرادات المنصة" },
            ["admin.kpi.tickets"]       = new Dictionary<string, string> { ["en"] = "Open tickets",                             ["ar"] = "تذاكر مفتوحة" },
            ["admin.traffic"]           = new Dictionary<string, string> { ["en"] = "Traffic analytics",                        ["ar"] = "تحليلات الزيارات" },
            ["admin.queue"]             = new Dictionary<string, string> { ["en"] = "Reports queue",                            ["ar"] = "قائمة التقارير" },
            ["admin.support"]           = new Dictionary<string, string> { ["en"] = "Support tickets",                          ["ar"] = "تذاكر الدعم" },
            ["admin.signups"]           = new Dictionary<string, string> { ["en"] = "Signups breakdown",                        ["ar"] = "توزيع التسجيلات" },

            // --- Course catalog ---
            ["cat.title"]               = new Dictionary<string, string> { ["en"] = "Explore the catalog",                      ["ar"] = "استكشف المكتبة" },
            ["cat.subtitle"]            = new Dictionary<string, string> { ["en"] = "Discover 1,200+ expert-led courses across 30 categories.", ["ar"] = "اكتشف أكثر من 1200 دورة في أكثر من 30 فئة." },
            ["cat.filter.all"]          = new Dictionary<string, string> { ["en"] = "All",                                      ["ar"] = "الكل" },
            ["cat.filter.category"]     = new Dictionary<string, string> { ["en"] = "Category",                                 ["ar"] = "الفئة" },
            ["cat.filter.level"]        = new Dictionary<string, string> { ["en"] = "Level",                                    ["ar"] = "المستوى" },
            ["cat.filter.price"]        = new Dictionary<string, string> { ["en"] = "Price",                                    ["ar"] = "السعر" },
            ["cat.filter.rating"]       = new Dictionary<string, string> { ["en"] = "Rating",                                   ["ar"] = "التقييم" },
            ["cat.filter.language"]     = new Dictionary<string, string> { ["en"] = "Language",                                 ["ar"] = "اللغة" },
            ["cat.filter.instructor"]   = new Dictionary<string, string> { ["en"] = "Instructor",                               ["ar"] = "المدرّب" },
            ["cat.bestseller"]          = new Dictionary<string, string> { ["en"] = "Bestseller",                               ["ar"] = "الأكثر مبيعًا" },
            ["cat.new"]                 = new Dictionary<string, string> { ["en"] = "New",                                      ["ar"] = "جديد" },
            ["cat.beginner"]            = new Dictionary<string, string> { ["en"] = "Beginner",                                 ["ar"] = "مبتدئ" },
            ["cat.intermediate"]        = new Dictionary<string, string> { ["en"] = "Intermediate",                             ["ar"] = "متوسط" },
            ["cat.advanced"]            = new Dictionary<string, string> { ["en"] = "Advanced",                                 ["ar"] = "متقدّم" },
            ["cat.students"]            = new Dictionary<string, string> { ["en"] = "students",                                 ["ar"] = "طالب" },
            ["cat.hours"]               = new Dictionary<string, string> { ["en"] = "hours",                                    ["ar"] = "ساعة" },
            ["cat.lessons"]             = new Dictionary<string, string> { ["en"] = "lessons",                                  ["ar"] = "درس" },
            ["cat.enroll"]              = new Dictionary<string, string> { ["en"] = "Enroll",                                   ["ar"] = "سجّل الآن" },
            ["cat.preview"]             = new Dictionary<string, string> { ["en"] = "Preview",                                  ["ar"] = "معاينة" },
            ["cat.free"]                = new Dictionary<string, string> { ["en"] = "Free",                                     ["ar"] = "مجاني" },

            // --- Course learning page ---
            ["learn.tab.overview"]      = new Dictionary<string, string> { ["en"] = "Overview",                                 ["ar"] = "نظرة عامة" },
            ["learn.tab.notes"]         = new Dictionary<string, string> { ["en"] = "Notes",                                    ["ar"] = "الملاحظات" },
            ["learn.tab.resources"]     = new Dictionary<string, string> { ["en"] = "Resources",                                ["ar"] = "الموارد" },
            ["learn.tab.discussion"]    = new Dictionary<string, string> { ["en"] = "Discussion",                               ["ar"] = "النقاش" },
            ["learn.tab.quiz"]          = new Dictionary<string, string> { ["en"] = "Quiz",                                     ["ar"] = "اختبار" },
            ["learn.curriculum"]        = new Dictionary<string, string> { ["en"] = "Curriculum",                               ["ar"] = "المنهج" },
            ["learn.progress"]          = new Dictionary<string, string> { ["en"] = "Progress",                                 ["ar"] = "التقدّم" },
            ["learn.bookmark"]          = new Dictionary<string, string> { ["en"] = "Bookmark",                                 ["ar"] = "إضافة علامة" },
            ["learn.markComplete"]      = new Dictionary<string, string> { ["en"] = "Mark complete",                            ["ar"] = "وضع علامة كمكتمل" },
            ["learn.takeNote"]          = new Dictionary<string, string> { ["en"] = "Take a note…",                             ["ar"] = "اكتب ملاحظة..." },

            // --- Profile / settings ---
            ["profile.title"]           = new Dictionary<string, string> { ["en"] = "Account & preferences",                    ["ar"] = "الحساب والتفضيلات" },
            ["profile.tab.personal"]    = new Dictionary<string, string> { ["en"] = "Personal info",                            ["ar"] = "المعلومات الشخصية" },
            ["profile.tab.security"]    = new Dictionary<string, string> { ["en"] = "Security",                                 ["ar"] = "الأمان" },
            ["profile.tab.notifications"]=new Dictionary<string,string>  { ["en"] = "Notifications",                            ["ar"] = "الإشعارات" },
            ["profile.tab.language"]    = new Dictionary<string, string> { ["en"] = "Language",                                 ["ar"] = "اللغة" },
            ["profile.tab.billing"]     = new Dictionary<string, string> { ["en"] = "Billing",                                  ["ar"] = "الفوترة" },
            ["profile.tab.history"]     = new Dictionary<string, string> { ["en"] = "Learning history",                         ["ar"] = "سجل التعلّم" },
            ["profile.save"]            = new Dictionary<string, string> { ["en"] = "Save changes",                             ["ar"] = "حفظ التغييرات" },

            // --- Footer ---
            ["foot.copy"]               = new Dictionary<string, string> { ["en"] = "© 2026 ArkkanLMS",                         ["ar"] = "© 2026 أركان للتعلم" },
            ["foot.privacy"]            = new Dictionary<string, string> { ["en"] = "Privacy",                                  ["ar"] = "الخصوصية" },
            ["foot.terms"]              = new Dictionary<string, string> { ["en"] = "Terms",                                    ["ar"] = "الشروط" },
            ["foot.contact"]            = new Dictionary<string, string> { ["en"] = "Contact",                                  ["ar"] = "تواصل" },
        };

        public static string Get(string key, string culture)
        {
            if (Translations.TryGetValue(key, out var dict))
            {
                if (dict.TryGetValue(culture, out var v)) return v;
                if (dict.TryGetValue(DefaultCulture, out var fallback)) return fallback;
            }
            return key;
        }
    }
}
