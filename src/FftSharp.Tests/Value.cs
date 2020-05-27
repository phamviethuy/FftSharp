﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace FftSharp.Tests
{
    class Value
    {

        [Test]
        public void Test_FFT_ValuesMatchNumpy()
        {
            // Some sample audio data was analyzed with Numpy in Python.
            // This module contains the output of numpy.fft.fft()
            // https://numpy.org/doc/1.18/reference/generated/numpy.fft.fft.html
            // This test assserts our FFT results match Numpy's

            Complex[] fft = FftSharp.Transform.FFT(audio);
            for (int i = 0; i < fft.Length; i++)
            {
                Assert.AreEqual(numpyFFT[i].Real, fft[i].Real, 1e-12);
                Assert.AreEqual(numpyFFT[i].Imaginary, fft[i].Imaginary, 1e-12);
            }
        }

        [Test]
        public void Test_FFTfast_ValuesMatchNumpy()
        {
            // Some sample audio data was analyzed with Numpy in Python.
            // This module contains the output of numpy.fft.fft()
            // https://numpy.org/doc/1.18/reference/generated/numpy.fft.fft.html
            // This test assserts our FFT results match Numpy's

            Complex[] fft = new Complex[audio.Length];
            for (int i = 0; i < audio.Length; i++)
                fft[i] = new Complex(audio[i], 0);
            FftSharp.Transform.FFT(fft);

            for (int i = 0; i < fft.Length; i++)
            {
                Assert.AreEqual(numpyFFT[i].Real, fft[i].Real, 1e-12);
                Assert.AreEqual(numpyFFT[i].Imaginary, fft[i].Imaginary, 1e-12);
            }
        }

        private readonly double[] audio =
        {
            0.330, 2.150, 1.440, 1.370, 0.240, 2.600, 3.510, 1.980, 1.880, 0.080,
            1.820, 1.300, 0.230, -1.160, -1.350, -0.580, -0.840, -1.350, -2.720, -2.530,
            -0.020, -0.760, -0.480, -2.100, 0.300, 1.860, 1.600, 1.490, 0.580, 2.120,
            2.790, 1.990, 1.200, 0.800, 2.180, 1.600, -0.370, -1.250, -1.990, 0.350,
            -1.190, -1.620, -3.280, -2.570, 0.070, -0.810, -1.130, -1.680, -0.250, 1.550,
            1.080, 1.530, 0.650, 2.530, 2.790, 2.420, 1.720, 0.540, 2.390, 1.510,
            0.220, -1.420, -1.440, 0.290, -1.610, -1.500, -3.230, -2.200, -0.010, -1.390,
            -0.470, -1.650, 0.250, 2.050, 1.480, 0.910, 0.760, 2.760, 2.730, 2.450,
            1.090, 0.280, 2.070, 1.160, 0.270, -1.170, -1.500, 0.200, -0.910, -1.580,
            -2.460, -2.550, -0.310, -0.940, -1.130, -1.850, 0.420, 1.560, 0.850, 0.880,
            0.660, 2.730, 3.230, 2.470, 1.120, 0.740, 1.600, 1.730, 0.280, -1.540,
            -2.180, -0.500, -1.090, -1.390, -2.910, -2.690, -0.160, -1.040, -1.240, -1.520,
            -0.390, 1.690, 1.520, 0.870, 0.310, 2.750, 3.560, 2.530, 1.290, 0.330,
            1.810, 1.340, 0.130, -1.580, -2.050, -0.110, -0.850, -1.730, -3.300, -2.100,
            -0.430, -0.670, -1.340, -1.430, 0.220, 2.160, 1.350, 1.380, 0.210, 2.230,
            3.210, 1.790, 1.900, 0.380, 1.600, 1.100, 0.440, -1.070, -1.690, -0.090,
            -0.730, -2.260, -2.890, -2.680, -0.020, -0.960, -0.890, -1.580, 0.270, 2.330,
            0.970, 0.870, 0.500, 2.520, 2.820, 1.610, 1.130, -0.040, 1.980, 1.280,
            -0.380, -1.240, -1.520, -0.400, -0.790, -2.310, -2.890, -1.880, 0.160, -1.590,
            -0.810, -1.860, 0.570, 1.920, 1.440, 1.130, 0.450, 3.020, 3.490, 2.510,
            1.150, -0.060, 2.430, 1.010, 0.480, -1.090, -1.550, -0.090, -1.350, -1.350,
            -3.370, -2.150, -0.710, -1.410, -0.970, -1.550, -0.140, 1.640, 0.910, 1.590,
            0.170, 2.650, 3.160, 2.200, 1.240, -0.170, 1.630, 1.710, 0.310, -0.740,
            -1.680, -0.350, -1.430, -1.870, -3.200, -1.950, -0.340, -0.970, -1.150, -1.760,
            -0.160, 2.330, 1.280, 0.810, 1.020, 3.000, 2.760, 2.310, 0.990, -0.000,
            1.600, 0.940, 0.330, -1.530, -1.490, 0.040, -1.130, -2.100, -2.560, -1.980,
            -0.390, -0.700, -0.660, -1.670, -0.060, 2.110, 1.090, 1.450, 1.030, 2.650,
            2.690, 2.160, 1.890, 0.680, 2.070, 0.970, -0.400, -1.080, -1.660, -0.230,
            -0.830, -2.020, -2.610, -2.320, -0.000, -1.070, -0.940, -1.970, 0.230, 1.890,
            0.980, 1.060, 0.830, 2.500, 3.520, 1.880, 1.090, -0.040, 2.190, 1.040,
            0.130, -1.120, -1.560, -0.120, -1.600, -1.900, -3.280, -1.980, -0.270, -0.900,
            -0.830, -2.120, 0.170, 1.790, 1.660, 0.930, 0.150, 2.320, 3.230, 2.340,
            1.150, 0.070, 1.550, 1.280, -0.110, -0.790, -1.510, -0.080, -0.750, -2.140,
            -2.450, -1.990, 0.060, -1.140, -0.620, -1.780, 0.150, 1.640, 1.090, 1.200,
            0.450, 2.700, 3.200, 2.470, 1.810, 0.110, 2.210, 1.180, 0.070, -0.830,
            -2.120, 0.300, -1.180, -1.480, -2.450, -2.570, -0.340, -1.280, -1.280, -1.870,
            0.220, 1.920, 1.580, 1.170, 0.790, 2.830, 2.720, 1.640, 1.510, 0.440,
            2.100, 1.650, 0.460, -1.390, -1.960, -0.010, -1.040, -2.260, -2.870, -1.850,
            -0.670, -1.130, -1.400, -1.980, 0.590, 1.370, 1.000, 0.840, 0.550, 2.610,
            3.460, 1.760, 1.020, -0.040, 2.310, 1.670, 0.350, -1.390, -2.160, -0.480,
            -1.520, -1.760, -2.670, -2.010, -0.600, -1.210, -1.420, -1.850, 0.080, 1.690,
            1.270, 1.220, 0.830, 2.230, 2.700, 1.680, 1.420, 0.560, 1.910, 1.550,
            0.060, -1.550, -1.750, -0.570, -0.920, -1.990, -2.700, -2.130, -0.370, -1.060,
            -0.630, -1.710, 0.510, 1.740, 1.480, 1.390, 0.780, 2.270, 3.520, 2.130,
            1.890, -0.140, 2.080, 0.990, 0.570, -1.190, -1.900, 0.320, -1.640, -1.700,
            -3.090, -1.840, 0.030, -1.150, -0.800, -2.040, 0.590, 2.020, 0.720, 1.690,
            0.730, 2.380, 3.420, 2.480, 1.420, -0.010, 2.040, 1.220, -0.020, -1.110,
            -1.950, -0.320, -0.870, -1.550, -2.670, -2.440, -0.300, -1.180, -1.390, -1.800,
            0.520, 2.110, 1.320, 1.630, 0.270, 2.880, 3.160, 1.990, 1.640, 0.530,
            2.120, 0.900, -0.220, -1.590, -1.450, 0.050, -1.460, -1.730, -2.760, -2.060,
            0.100, -1.560, -0.920, -1.600, -0.140, 1.350, 0.830, 0.880, 0.760, 2.300,
            3.160, 2.110,
        };

        // generated with python/Numpy: fft = numpy.fft.fft(sampleAudio1)
        private readonly Complex[] numpyFFT =
        {
            new Complex(71.52, 0.0),
            new Complex(16.292599219664993, -1.650266240953031),
            new Complex(16.58819220541474, -4.456837908626264),
            new Complex(11.867798701774102, 0.7429551118770812),
            new Complex(6.339252942386048, 1.3944730123175706),
            new Complex(5.091353556901778, -4.23187134652945),
            new Complex(18.814490506606102, -8.665625451587731),
            new Complex(16.81258122144206, 1.5049383063313775),
            new Complex(16.250262936175652, -10.898983835764772),
            new Complex(9.653138749580403, -3.4907810508138843),
            new Complex(13.307669165815344, -4.967069973560199),
            new Complex(14.963784782916647, -12.000161985633959),
            new Complex(11.96745034011839, -6.99870154432028),
            new Complex(20.457611574040772, -7.503111641685473),
            new Complex(16.65888595885314, -13.091972828691972),
            new Complex(21.507612856521956, -0.699201769934322),
            new Complex(26.771895548958383, -16.35220257819907),
            new Complex(31.077223230796143, -16.494436421460076),
            new Complex(45.10852008979767, -20.58984095476262),
            new Complex(59.25922110005847, -29.04396354790871),
            new Complex(94.30531062507758, -51.976078289996565),
            new Complex(366.88585732605077, -205.12349027793272),
            new Complex(-177.8491671506428, 105.09540721761974),
            new Complex(-71.83350266181674, 50.22287606700222),
            new Complex(-45.553168448188615, 26.10712988794811),
            new Complex(-20.986245062901816, 15.999954756852027),
            new Complex(-24.858594932136125, 13.645918510329325),
            new Complex(-19.173373012705525, 16.449007609589398),
            new Complex(-8.537098037860998, 8.88530912169331),
            new Complex(-11.266585527651117, 8.094594399106153),
            new Complex(-9.241923204154396, -1.847317739378453),
            new Complex(-10.46615838300978, 4.64345496924585),
            new Complex(-12.27027085039127, 5.87765864860703),
            new Complex(-7.370274298222351, 6.341810090314409),
            new Complex(-1.2131051366901628, 6.993893647840464),
            new Complex(-6.1359988292690755, 7.692984484782312),
            new Complex(4.091706423869168, 1.365798023974214),
            new Complex(-4.655458008198221, -0.7217109700711242),
            new Complex(-4.463444898038833, 2.2094751854192),
            new Complex(-2.4342160634907675, 11.254011503392162),
            new Complex(5.098783312195228, 4.827669742579822),
            new Complex(-5.831778282084546, 4.025856294966041),
            new Complex(3.665136034495667, 5.806578149334394),
            new Complex(-6.782761994698575, 12.087457969879013),
            new Complex(-0.454577044366566, 8.989165374120152),
            new Complex(1.1190972614148489, 7.3826047223482005),
            new Complex(-5.300512604596365, 3.3787295501896804),
            new Complex(-5.303638228818758, 0.663150420740581),
            new Complex(-1.402392307772061, 4.385841205789253),
            new Complex(2.839320733358291, 6.177222092996357),
            new Complex(-5.471846454174141, -3.646041429888425),
            new Complex(-0.1825607735763244, 4.335020541082649),
            new Complex(0.23366490444061006, 12.53115614224979),
            new Complex(-4.607834909859168, 2.731226568868507),
            new Complex(0.4407190353942614, 5.867753191224533),
            new Complex(-0.6346634815558851, 5.2502903349451495),
            new Complex(-4.644687701252085, 13.308500752662315),
            new Complex(-4.186255039897505, 1.883033665479715),
            new Complex(3.1011324895272105, 6.889303301004),
            new Complex(-5.994624072627106, 3.0893738437673104),
            new Complex(2.148665980983523, -2.165175261206472),
            new Complex(8.120784577044827, -1.026413324380261),
            new Complex(-2.736075709061385, 8.309850036461317),
            new Complex(-1.122976392687268, 1.3868358039512898),
            new Complex(-0.4420963209812834, 3.394939033455901),
            new Complex(10.571135745703966, -7.214497105214868),
            new Complex(-0.6361813663828921, 6.457986031215809),
            new Complex(-0.0025957626844732573, 9.037941129554671),
            new Complex(-2.797973427324928, -1.3949959065210518),
            new Complex(0.32042128744426146, 5.166759010512948),
            new Complex(1.8672167221767477, 3.7484970064639),
            new Complex(4.284785289539634, 11.97800470285899),
            new Complex(-1.9130289340345799, 4.890086838063299),
            new Complex(-8.063646970616297, 7.70671282524425),
            new Complex(-2.5076616550924244, -0.5616066179697525),
            new Complex(4.848590964002215, 0.4155821028619835),
            new Complex(0.6519047716752894, 8.365467739744268),
            new Complex(5.925896594814173, 1.6214148805227862),
            new Complex(-0.11732472297714991, 2.084514460872517),
            new Complex(3.1379824354268417, -6.2577633910536195),
            new Complex(6.774385287871493, 9.629330590835693),
            new Complex(5.4393155868096645, -6.121406497914311),
            new Complex(1.0174178671562233, -8.607714904038465),
            new Complex(5.398310408984056, -7.203490766128718),
            new Complex(-3.785148744276335, 3.9182113455816534),
            new Complex(7.557346542357081, 6.081240307670624),
            new Complex(-8.76993242973248, 5.33687737351268),
            new Complex(-0.30138424584816725, 2.3135609200854255),
            new Complex(6.9465856216898105, 8.502927040297298),
            new Complex(-8.363128478889873, 9.156259453584855),
            new Complex(9.67066074018313, 4.95686087152842),
            new Complex(8.861238026483612, -0.9840687253038303),
            new Complex(10.426812822364912, -3.327862985228994),
            new Complex(7.296132588971696, 4.341249905128431),
            new Complex(2.513188500291645, 5.861603466455876),
            new Complex(-1.0480377808580927, 3.4893475665297666),
            new Complex(7.821845003550149, -1.9841378599467063),
            new Complex(-1.6324823820087873, 7.790777253754385),
            new Complex(8.970903795772337, 4.066014902164978),
            new Complex(-1.6707970781871344, 2.136015162752384),
            new Complex(7.25823248662058, 2.7652788765225464),
            new Complex(18.74397062908053, 8.896718444008549),
            new Complex(2.1660703208919037, -0.16068219834732878),
            new Complex(13.825097858675338, 8.427493951505237),
            new Complex(18.47832853222178, 12.667650849412713),
            new Complex(37.569125833815264, 21.578994508186412),
            new Complex(90.94566028906655, 50.697370827337764),
            new Complex(-191.4717302736666, -117.08331011378777),
            new Complex(-51.32832640613284, -23.124699639369688),
            new Complex(-23.500774862545306, -12.60161060026162),
            new Complex(-23.59827162418354, -16.220434411970672),
            new Complex(-21.623922884263543, -12.128429398236538),
            new Complex(-8.156016294103669, -2.0796298320611637),
            new Complex(-3.320934257799828, -4.826944007044764),
            new Complex(-8.966686390330285, 2.8174321266953233),
            new Complex(-4.036510916197747, -8.306905035682055),
            new Complex(-9.118052343426735, -0.7998264524711765),
            new Complex(1.7056006968282986, 2.48014371582694),
            new Complex(-0.4317759856237964, -2.0729669596807687),
            new Complex(1.3875511565884053, -2.3921170941765446),
            new Complex(-7.976980514611284, 4.704983072668933),
            new Complex(-1.0412939420119793, 2.0304346948254044),
            new Complex(-0.4712297547813127, -1.8877908393403056),
            new Complex(-12.834400468053518, -1.928010984003001),
            new Complex(-0.4020716349072191, -4.708004655448063),
            new Complex(-8.267438571150924, -3.7039764685576895),
            new Complex(-4.8684310845372405, -5.189260677129305),
            new Complex(0.4631251388647053, 1.0836107137372681),
            new Complex(0.9899999999999949, -2.049999999999997),
            new Complex(-4.84931978116202, -0.23933081088023878),
            new Complex(-9.934189775670093, 0.7971585720723557),
            new Complex(-2.600011910104527, -0.9923343205338109),
            new Complex(-2.160469164514625, -5.322803319988892),
            new Complex(-8.342213173106142, -0.17252901564132728),
            new Complex(-4.196598202151177, -4.7274680682126755),
            new Complex(-4.944944633762713, -1.4791201736168527),
            new Complex(-6.434479741808574, 6.482812912010042),
            new Complex(-5.158937174706397, 3.713563429843517),
            new Complex(-2.5917604439233597, -1.074410553473996),
            new Complex(1.6430036734162927, -0.26848993074113725),
            new Complex(-4.68619932790007, 3.5540911138722024),
            new Complex(-9.114112417604312, -5.863251584381021),
            new Complex(-1.511010285838398, 0.5916676752843228),
            new Complex(-1.0248996347649997, -5.221535985301575),
            new Complex(-5.907774632673288, 3.6263871521782516),
            new Complex(-0.8134349081877801, -2.8827110905821716),
            new Complex(-3.8883597256888898, 6.5096521647811105),
            new Complex(3.6028695146052687, 4.906754934650181),
            new Complex(-1.43392165399176, 0.09877393185500516),
            new Complex(2.5399337102167436, -2.6091846772843255),
            new Complex(-2.4029291340916004, 4.978313193479735),
            new Complex(-3.715287570789176, -4.39451837716846),
            new Complex(-10.306371528157012, -2.7488670997481837),
            new Complex(-0.024313261096906125, -5.986905188653612),
            new Complex(-2.8298389130063915, 3.448368650672101),
            new Complex(4.7341520993712995, -11.062510314288573),
            new Complex(-5.3829294937018854, -2.783057603406332),
            new Complex(0.0026383233212190493, -0.18978654624226898),
            new Complex(-1.8812828884644066, 4.871022697842905),
            new Complex(-3.2509005555527533, 1.4393838886348913),
            new Complex(-2.3369676800222434, 2.482582201564716),
            new Complex(-1.2142355119041524, 0.1834635506672304),
            new Complex(-9.582245656802916, -0.027020924935291735),
            new Complex(-6.581883483527928, -0.9168370285871652),
            new Complex(2.23633907309973, -2.3021508943840727),
            new Complex(-2.0748219655573625, -2.0037979487038773),
            new Complex(-3.765563906978262, 3.088432721629983),
            new Complex(5.332530718835812, -2.0516059158581865),
            new Complex(-0.2549012255641858, -0.6932903665209049),
            new Complex(-7.277178212857739, 2.9116631246832343),
            new Complex(-2.1936009994012435, 0.4001679051474425),
            new Complex(-8.794157662232939, 3.5717135906207176),
            new Complex(9.191032309546063, -1.9398929261634499),
            new Complex(-3.869682067783085, 0.5152936097585425),
            new Complex(3.147392558038452, 2.216334156350135),
            new Complex(4.337683896574441, 0.82997589223395),
            new Complex(5.8600818792670735, 0.02923610475152838),
            new Complex(-2.7839860346841525, 2.4914655265099466),
            new Complex(-1.903842415258608, 1.4113411741607438),
            new Complex(-9.894054706023422, 4.9668960901740284),
            new Complex(-0.8081382242155792, 11.349170741938877),
            new Complex(8.373197781633165, 2.1638002986517635),
            new Complex(-2.4852724753585846, 4.218258048332267),
            new Complex(-3.755737925182469, -4.490350833996583),
            new Complex(-2.879274257660312, 2.1626921190768043),
            new Complex(0.7024288556739815, -0.03525952952816347),
            new Complex(-2.673777491391463, 2.058724091865224),
            new Complex(2.1942581278786912, -4.751521874754496),
            new Complex(3.8112923807165675, 3.5946006951844867),
            new Complex(4.095532859213184, -0.28973422842765917),
            new Complex(-6.83825512481851, -9.6297170417451),
            new Complex(-1.9910301634396683, -10.188877845696899),
            new Complex(-1.4179036790187196, -3.8050609665441018),
            new Complex(-4.500591208775358, 2.5115489328726808),
            new Complex(2.5605067559698993, -1.0184596329131184),
            new Complex(6.717336341148254, -1.1098887472444834),
            new Complex(-3.6308727316719613, -2.930509025563401),
            new Complex(-1.2800687813817113, -5.2293267918825705),
            new Complex(-0.24178054270822846, -0.34674641143824747),
            new Complex(-3.5825821902320762, -6.877312499750982),
            new Complex(-2.602886071425474, -6.86407264784425),
            new Complex(-1.2785892290938932, -1.6397567663004344),
            new Complex(-8.675100612964963, -7.055963310707158),
            new Complex(8.84974247542792, -6.56325254726892),
            new Complex(2.885016983143895, -6.95362008379264),
            new Complex(6.918222156603157, 9.497082265446183),
            new Complex(4.10405309937396, -7.9120673382156275),
            new Complex(-1.584044627114519, -3.1949874308238275),
            new Complex(0.3670925294266434, -1.6673485244636947),
            new Complex(0.29461814038296197, -10.528089110189706),
            new Complex(10.194833330276264, -7.1146946624422025),
            new Complex(17.627086740678745, -7.638274663697334),
            new Complex(22.6731707587984, -11.536058001405237),
            new Complex(90.79168081510915, -41.13328830004425),
            new Complex(-43.229531626011074, 23.294890907589057),
            new Complex(-17.52387246706339, 7.853673956180025),
            new Complex(-15.806202527275513, -0.5183772215827949),
            new Complex(-25.289765401997723, 13.089544474677414),
            new Complex(-7.587901316147817, 6.612185770225549),
            new Complex(-7.7510301280002984, -4.450483522400161),
            new Complex(3.0154490825863447, 4.85718259595836),
            new Complex(-5.588006589467025, 1.8753775661904744),
            new Complex(-4.522700439505712, -6.941653406278663),
            new Complex(-9.29990757512051, 7.73164297352557),
            new Complex(-15.054606473136637, -4.415621289881546),
            new Complex(-5.649212036777634, -3.004224743561956),
            new Complex(-5.3245866110889075, -2.3232079416455855),
            new Complex(-6.09582893633526, -2.833602503098011),
            new Complex(2.3719671688372457, 7.823224635184997),
            new Complex(-4.378899544434763, -2.1004484536234473),
            new Complex(-1.847804254120236, -1.2174634584260025),
            new Complex(-7.151969645971247, 5.608493469097141),
            new Complex(-6.962043610144818, 2.4741041607524394),
            new Complex(-0.9411822402381276, 6.274216197339793),
            new Complex(0.501900088529041, -4.787955462633128),
            new Complex(-1.1594019555348325, -3.84174782623154),
            new Complex(3.3001766896560056, 2.9594456628498946),
            new Complex(-10.066436810536924, 0.6384104860672224),
            new Complex(-7.19567825040399, -3.2261296085795568),
            new Complex(-4.691470830071458, 2.9464762422417987),
            new Complex(-0.14727201097456977, -4.859280838128437),
            new Complex(-14.56692223701291, -7.90084256027122),
            new Complex(-4.324446487468897, 0.004185311431190719),
            new Complex(-1.0407514948403307, 2.059605296404119),
            new Complex(-2.98340696573519, -3.1029075652331937),
            new Complex(-4.636760771943916, 10.373963334679214),
            new Complex(-8.26960957572124, 0.7354864925759217),
            new Complex(-4.979951151973244, 2.4789920137824786),
            new Complex(1.4400641578399824, 0.8869891013658968),
            new Complex(0.6818750261182362, 2.470099039214686),
            new Complex(8.336841493956832, 7.404955214008821),
            new Complex(2.8157431492244953, -6.567660517080393),
            new Complex(-5.878260543893631, 8.516509649574305),
            new Complex(2.879678032286943, -3.1017131232821384),
            new Complex(-3.801558789466788, -2.7381256767431728),
            new Complex(-0.27745160787512013, -7.4993828895293335),
            new Complex(11.019999999999996, 0.0),
            new Complex(-0.2774516078751077, 7.499382889529332),
            new Complex(-3.801558789466789, 2.738125676743172),
            new Complex(2.8796780322869546, 3.101713123282132),
            new Complex(-5.87826054389363, -8.516509649574308),
            new Complex(2.8157431492244895, 6.567660517080403),
            new Complex(8.336841493956836, -7.404955214008817),
            new Complex(0.6818750261182362, -2.470099039214685),
            new Complex(1.4400641578399824, -0.8869891013658968),
            new Complex(-4.979951151973249, -2.4789920137824777),
            new Complex(-8.269609575721244, -0.7354864925759133),
            new Complex(-4.636760771943918, -10.373963334679196),
            new Complex(-2.9834069657351927, 3.1029075652331986),
            new Complex(-1.0407514948403325, -2.0596052964041296),
            new Complex(-4.324446487468897, -0.004185311431191607),
            new Complex(-14.566922237012907, 7.900842560271221),
            new Complex(-0.14727201097457154, 4.85928083812844),
            new Complex(-4.691470830071458, -2.9464762422418005),
            new Complex(-7.195678250403994, 3.2261296085795585),
            new Complex(-10.066436810536924, -0.6384104860672206),
            new Complex(3.3001766896559985, -2.9594456628499017),
            new Complex(-1.1594019555349178, 3.84174782623154),
            new Complex(0.5019000885290694, 4.787955462633128),
            new Complex(-0.9411822402381276, -6.274216197339783),
            new Complex(-6.962043610144818, -2.4741041607524394),
            new Complex(-7.151969645971249, -5.608493469097138),
            new Complex(-1.8478042541202342, 1.2174634584260051),
            new Complex(-4.378899544434763, 2.100448453623444),
            new Complex(2.3719671688372457, -7.8232246351849986),
            new Complex(-6.09582893633526, 2.833602503098014),
            new Complex(-5.324586611088915, 2.3232079416455873),
            new Complex(-5.649212036777634, 3.0042247435619593),
            new Complex(-15.054606473136637, 4.415621289881546),
            new Complex(-9.299907575120518, -7.731642973525572),
            new Complex(-4.522700439505707, 6.941653406278663),
            new Complex(-5.58800658946703, -1.8753775661904735),
            new Complex(3.015449082586345, -4.85718259595836),
            new Complex(-7.751030128000305, 4.45048352240015),
            new Complex(-7.587901316147819, -6.612185770225553),
            new Complex(-25.289765401997727, -13.089544474677405),
            new Complex(-15.806202527275513, 0.5183772215827931),
            new Complex(-17.523872467063388, -7.853673956180031),
            new Complex(-43.229531626011074, -23.294890907589064),
            new Complex(90.79168081510915, 41.13328830004425),
            new Complex(22.6731707587984, 11.536058001405241),
            new Complex(17.62708674067875, 7.6382746636973495),
            new Complex(10.194833330276262, 7.114694662442204),
            new Complex(0.2946181403829593, 10.528089110189704),
            new Complex(0.3670925294266425, 1.6673485244636956),
            new Complex(-1.584044627114522, 3.1949874308238337),
            new Complex(4.104053099373957, 7.912067338215623),
            new Complex(6.918222156603163, -9.497082265446183),
            new Complex(2.8850169831438968, 6.953620083792638),
            new Complex(8.849742475427908, 6.563252547268917),
            new Complex(-8.675100612964956, 7.0559633107071535),
            new Complex(-1.2785892290938947, 1.6397567663004302),
            new Complex(-2.602886071425475, 6.86407264784425),
            new Complex(-3.5825821902320816, 6.877312499750978),
            new Complex(-0.2417805427082258, 0.346746411438247),
            new Complex(-1.280068781381706, 5.229326791882579),
            new Complex(-3.6308727316719613, 2.930509025563401),
            new Complex(6.717336341148264, 1.1098887472444712),
            new Complex(2.560506755969895, 1.0184596329131175),
            new Complex(-4.500591208775362, -2.511548932872677),
            new Complex(-1.4179036790187196, 3.8050609665441018),
            new Complex(-1.9910301634396674, 10.1888778456969),
            new Complex(-6.838255124818515, 9.629717041745097),
            new Complex(4.095532859213191, 0.28973422842765384),
            new Complex(3.8112923807165693, -3.5946006951844875),
            new Complex(2.194258127878689, 4.751521874754488),
            new Complex(-2.6737774913914603, -2.0587240918652236),
            new Complex(0.7024288556739806, 0.03525952952816347),
            new Complex(-2.8792742576603123, -2.162692119076805),
            new Complex(-3.7557379251824736, 4.490350833996582),
            new Complex(-2.4852724753585793, -4.21825804833226),
            new Complex(8.373197781633138, -2.1638002986517675),
            new Complex(-0.8081382242155787, -11.349170741938874),
            new Complex(-9.894054706023425, -4.966896090174037),
            new Complex(-1.9038424152586149, -1.4113411741607438),
            new Complex(-2.78398603468415, -2.491465526509942),
            new Complex(5.8600818792670735, -0.029236104751530156),
            new Complex(4.337683896574438, -0.8299758922339566),
            new Complex(3.147392558038458, -2.216334156350134),
            new Complex(-3.869682067783092, -0.5152936097585532),
            new Complex(9.191032309546063, 1.9398929261634485),
            new Complex(-8.79415766223292, -3.5717135906207194),
            new Complex(-2.193600999401239, -0.40016790514745004),
            new Complex(-7.277178212857741, -2.911663124683228),
            new Complex(-0.2549012255641854, 0.6932903665209089),
            new Complex(5.3325307188358035, 2.0516059158581808),
            new Complex(-3.765563906978266, -3.0884327216299763),
            new Complex(-2.0748219655573683, 2.0037979487038813),
            new Complex(2.236339073099729, 2.3021508943840754),
            new Complex(-6.581883483527934, 0.9168370285871648),
            new Complex(-9.582245656802918, 0.027020924935293067),
            new Complex(-1.2142355119041532, -0.18346355066723263),
            new Complex(-2.3369676800222434, -2.482582201564716),
            new Complex(-3.2509005555527524, -1.439383888634893),
            new Complex(-1.881282888464412, -4.871022697842905),
            new Complex(0.002638323321221492, 0.18978654624225966),
            new Complex(-5.3829294937018854, 2.7830576034063332),
            new Complex(4.734152099371303, 11.062510314288577),
            new Complex(-2.8298389130063937, -3.448368650672099),
            new Complex(-0.024313261096907013, 5.986905188653619),
            new Complex(-10.306371528157014, 2.7488670997481854),
            new Complex(-3.715287570789169, 4.394518377168463),
            new Complex(-2.402929134091579, -4.978313193479721),
            new Complex(2.539933710216687, 2.609184677284304),
            new Complex(-1.4339216539917672, -0.09877393185499805),
            new Complex(3.602869514605274, -4.906754934650175),
            new Complex(-3.8883597256888915, -6.509652164781107),
            new Complex(-0.8134349081877765, 2.8827110905821733),
            new Complex(-5.907774632673294, -3.6263871521782534),
            new Complex(-1.0248996347650001, 5.221535985301575),
            new Complex(-1.5110102858383998, -0.5916676752843197),
            new Complex(-9.114112417604304, 5.863251584381027),
            new Complex(-4.6861993279000735, -3.5540911138722056),
            new Complex(1.643003673416314, 0.26848993074112837),
            new Complex(-2.5917604439233606, 1.0744105534739878),
            new Complex(-5.1589371747064, -3.713563429843524),
            new Complex(-6.434479741808579, -6.482812912010042),
            new Complex(-4.944944633762709, 1.4791201736168564),
            new Complex(-4.196598202151179, 4.72746806821267),
            new Complex(-8.342213173106137, 0.17252901564131817),
            new Complex(-2.160469164514622, 5.322803319988891),
            new Complex(-2.600011910104522, 0.9923343205338124),
            new Complex(-9.934189775670099, -0.7971585720723513),
            new Complex(-4.8493197811620155, 0.23933081088024055),
            new Complex(0.9899999999999949, 2.049999999999997),
            new Complex(0.46312513886469997, -1.083610713737262),
            new Complex(-4.8684310845372405, 5.189260677129301),
            new Complex(-8.26743857115093, 3.7039764685576912),
            new Complex(-0.4020716349072171, 4.7080046554480655),
            new Complex(-12.834400468053516, 1.9280109840029835),
            new Complex(-0.471229754781314, 1.8877908393403002),
            new Complex(-1.0412939420119778, -2.030434694825405),
            new Complex(-7.976980514611285, -4.704983072668933),
            new Complex(1.3875511565884113, 2.3921170941765437),
            new Complex(-0.43177598562379993, 2.072966959680773),
            new Complex(1.7056006968282746, -2.4801437158269524),
            new Complex(-9.118052343426733, 0.7998264524711733),
            new Complex(-4.03651091619774, 8.306905035682062),
            new Complex(-8.966686390330285, -2.8174321266953237),
            new Complex(-3.3209342577998275, 4.826944007044759),
            new Complex(-8.156016294103669, 2.0796298320611637),
            new Complex(-21.623922884263532, 12.12842939823654),
            new Complex(-23.59827162418354, 16.220434411970665),
            new Complex(-23.5007748625453, 12.601610600261623),
            new Complex(-51.32832640613283, 23.124699639369688),
            new Complex(-191.47173027366654, 117.08331011378777),
            new Complex(90.94566028906652, -50.697370827337764),
            new Complex(37.569125833815264, -21.57899450818642),
            new Complex(18.47832853222178, -12.667650849412711),
            new Complex(13.825097858675331, -8.427493951505243),
            new Complex(2.1660703208919014, 0.160682198347327),
            new Complex(18.743970629080533, -8.896718444008545),
            new Complex(7.258232486620578, -2.765278876522548),
            new Complex(-1.67079707818714, -2.1360151627523862),
            new Complex(8.970903795772342, -4.066014902164978),
            new Complex(-1.63248238200879, -7.790777253754383),
            new Complex(7.821845003550149, 1.9841378599467063),
            new Complex(-1.0480377808580839, -3.489347566529763),
            new Complex(2.5131885002916463, -5.861603466455877),
            new Complex(7.296132588971693, -4.341249905128436),
            new Complex(10.426812822364907, 3.327862985228995),
            new Complex(8.861238026483615, 0.9840687253038444),
            new Complex(9.670660740183134, -4.95686087152842),
            new Complex(-8.363128478889875, -9.156259453584862),
            new Complex(6.946585621689808, -8.5029270402973),
            new Complex(-0.30138424584816637, -2.313560920085428),
            new Complex(-8.769932429732478, -5.336877373512683),
            new Complex(7.557346542357086, -6.081240307670633),
            new Complex(-3.785148744276337, -3.918211345581653),
            new Complex(5.398310408984054, 7.203490766128711),
            new Complex(1.0174178671562275, 8.607714904038463),
            new Complex(5.439315586809667, 6.121406497914306),
            new Complex(6.774385287871493, -9.629330590835693),
            new Complex(3.1379824354268426, 6.257763391053615),
            new Complex(-0.11732472297715368, -2.0845144608725157),
            new Complex(5.925896594814177, -1.6214148805227864),
            new Complex(0.6519047716752884, -8.365467739744261),
            new Complex(4.848590964002236, -0.4155821028619928),
            new Complex(-2.5076616550924316, 0.5616066179697503),
            new Complex(-8.0636469706163, -7.706712825244248),
            new Complex(-1.9130289340345779, -4.890086838063298),
            new Complex(4.2847852895396334, -11.97800470285899),
            new Complex(1.8672167221767484, -3.748497006463906),
            new Complex(0.3204212874442627, -5.166759010512947),
            new Complex(-2.797973427324931, 1.3949959065210518),
            new Complex(-0.002595762684481251, -9.037941129554675),
            new Complex(-0.6361813663828864, -6.4579860312158095),
            new Complex(10.57113574570397, 7.214497105214866),
            new Complex(-0.4420963209812834, -3.394939033455901),
            new Complex(-1.1229763926872622, -1.3868358039512907),
            new Complex(-2.7360757090613825, -8.309850036461313),
            new Complex(8.120784577044823, 1.026413324380274),
            new Complex(2.1486659809835205, 2.165175261206473),
            new Complex(-5.99462407262711, -3.089373843767308),
            new Complex(3.1011324895272074, -6.8893033010039995),
            new Complex(-4.186255039897514, -1.883033665479715),
            new Complex(-4.644687701252083, -13.308500752662315),
            new Complex(-0.6346634815558894, -5.25029033494515),
            new Complex(0.4407190353942614, -5.8677531912245335),
            new Complex(-4.607834909859174, -2.7312265688684985),
            new Complex(0.23366490444060828, -12.531156142249792),
            new Complex(-0.18256077357631373, -4.335020541082644),
            new Complex(-5.471846454174138, 3.6460414298884283),
            new Complex(2.839320733358294, -6.1772220929963595),
            new Complex(-1.402392307772061, -4.385841205789253),
            new Complex(-5.303638228818758, -0.6631504207405765),
            new Complex(-5.3005126045963635, -3.37872955018968),
            new Complex(1.119097261414847, -7.382604722348194),
            new Complex(-0.45457704436656776, -8.989165374120152),
            new Complex(-6.782761994698582, -12.08745796987899),
            new Complex(3.6651360344956814, -5.806578149334387),
            new Complex(-5.831778282084541, -4.025856294966035),
            new Complex(5.098783312195226, -4.827669742579823),
            new Complex(-2.434216063490762, -11.25401150339216),
            new Complex(-4.463444898038834, -2.2094751854191976),
            new Complex(-4.655458008198199, 0.7217109700711257),
            new Complex(4.091706423869164, -1.3657980239742185),
            new Complex(-6.135998829269078, -7.692984484782302),
            new Complex(-1.213105136690158, -6.993893647840464),
            new Complex(-7.3702742982223475, -6.341810090314407),
            new Complex(-12.27027085039127, -5.87765864860703),
            new Complex(-10.466158383009784, -4.64345496924585),
            new Complex(-9.241923204154393, 1.8473177393784537),
            new Complex(-11.266585527651117, -8.094594399106146),
            new Complex(-8.537098037861002, -8.885309121693309),
            new Complex(-19.17337301270554, -16.4490076095894),
            new Complex(-24.85859493213612, -13.64591851032932),
            new Complex(-20.98624506290183, -15.99995475685203),
            new Complex(-45.553168448188615, -26.107129887948112),
            new Complex(-71.83350266181674, -50.22287606700222),
            new Complex(-177.8491671506428, -105.09540721761977),
            new Complex(366.88585732605077, 205.12349027793272),
            new Complex(94.3053106250776, 51.97607828999656),
            new Complex(59.25922110005847, 29.043963547908717),
            new Complex(45.108520089797665, 20.58984095476262),
            new Complex(31.077223230796157, 16.494436421460072),
            new Complex(26.77189554895839, 16.352202578199066),
            new Complex(21.50761285652196, 0.6992017699343238),
            new Complex(16.65888595885314, 13.091972828691969),
            new Complex(20.457611574040776, 7.5031116416854715),
            new Complex(11.967450340118393, 6.99870154432028),
            new Complex(14.963784782916644, 12.000161985633948),
            new Complex(13.307669165815334, 4.967069973560196),
            new Complex(9.653138749580414, 3.490781050813886),
            new Complex(16.250262936175652, 10.898983835764772),
            new Complex(16.81258122144206, -1.5049383063313797),
            new Complex(18.814490506606106, 8.665625451587735),
            new Complex(5.0913535569017805, 4.231871346529461),
            new Complex(6.3392529423860475, -1.3944730123175701),
            new Complex(11.867798701774106, -0.7429551118770841),
            new Complex(16.588192205414742, 4.456837908626263),
            new Complex(16.292599219664993, 1.6502662409530293),
        };
    }
}