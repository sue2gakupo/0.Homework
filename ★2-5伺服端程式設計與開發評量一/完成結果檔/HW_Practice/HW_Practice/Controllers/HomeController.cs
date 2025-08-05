using System.Diagnostics;
using HW_Practice.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW_Practice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

//���Ȥ@�G�Ш̾��D�D�W���ݨD�A�HCode-First�覡�إ߲ŦX�U�C�ݨD���ҫ����O�BDbContext�θ�Ʈw�A�����]�t�G
//1.	�D���ƪ�(�s��(P.K)�B�D�D�B�o���e�B�Ӥ��B�Ӥ������B�o��H�B�i�K�ɶ�)
//2.	�^�Ф��e��ƪ�(�s��(P.K)�B�^�Ф��e�B�^�ФH�B�^�Юɶ�)
//3.	�D���ƪ�P�^�Ф��e��ƪ��������p�A�@�h�D��i�H���ܦh�h�^�Ф��e�C
//4.	�M�צW�١B��Ʈw�θ�ƪ�W�٥i�ۭq�C
//5.	�U���O�����]�p�۹����ݩʸ�ƫ��A(Data Type)�����ҳW�h�C
//6.	���s�@��l�Ʈɤ��ؤl���(Seed Data)�Y�z���C
//���ȤG�G�г]�p�e�x(�ϥΪ̺�)�\��A�����]�t�G
//1.	�ϥΪ̥i�o��s�峹�A����x�s��D���ƪ�
//2.	�ϥΪ̵o��峹�ɶ���g�D�D�B�o���e�B�o��H���A�ӷӤ��i���i�L�C
//3.	�D�e���e�{�U�Q�פ峹�D�D�A�è̵o��ɶ����s���±ƦC�C
//4.	�I��D�D��i�i�J���Ӥ峹���Q�׵e���A�i�ݨ�D�夺�e�B�Ӥ��Φ^�Ф��e�C
//5.	�ϥΪ̥i�b�峹�Q�׵e���^�иӤ峹�C
//6.	�^�Ф峹�e�{�ɶ��̵o��ɶ����s���±ƦC�C
//���ȤT�G�����X��@��ϥθg��ζK���Ȫ��A�]�A��Ʀs�x���e�B�W�h�Ψϥάy�{�C

////////////////////////////////////////////////////////////////////////////////////
//MyModel_CodeFirst�M�׶i��B�J

//1. �ϥ�Code First�إ�Model�θ�Ʈw

//1.1   �bModels��Ƨ��̫إ�Book��ReBook������O�����ҫ�
//1.1.1 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��Book.cs�A���U�u�s�W�v�s
//1.1.2 �]�pBook���O���U�ݩʡA�]�A�W�١B��������Ψ���������ҳW�h����ܦW��(Display)
//1.1.3 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��ReBook.cs�A���U�u�s�W�v�s
//1.1.4 �]�pReBook���O���U�ݩʡA�]�A�W�١B��������Ψ���������ҳW�h����ܦW��(Display)
//1.1.5 ���g������O�������p�ݩʰ������Ӹ�ƪ��������p
//1.1.6 �إ�MeataData���O�A��Book��ReBook���O���ۤv�ҲK�[���{���X���Ӧ�MetaData���O��
//1.1.7 �ϥ�Partial Class���S�ʡA�NMeataData���O�е��������Book��ReBook���O�W(��l��Book��ReBook���O���bclass�e�[�Wpartial)
//���Q��MetaData���O�i�H�B��Partial Class���S�ʡA�N�쥻�y�z�b��class�����{���X�����X�ӡA�F����n���{���[�c�A�ϭ�Ӫ��{���X�O����l���A��
//���o�ӹ�@�ޥ��bDBFirst���׬����n�A�]���u�n���s����DBFirst�A�N�|���Ӫ��ҫ����e�л\���A�Ӽg�b�ҫ����O�����W�h�N�������s���g��



//1.2   �إ�DbContext���O
//      ���w�ˤU�C��ӮM��
//      (1)Microsoft.EntityFrameworkCore.SqlServer
//      (2)Microsoft.EntityFrameworkCore.Tools
//      ���PDB First�w�˪��M��@�ˡ�
//1.2.1 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��GuestBookContext.cs�A���U�u�s�W�v�s
//1.2.2 ���gGuestBookContext���O�����e
//      (1)���~��DbContext���O
//      (2)���g�̿�`�J�Ϊ��غc�l
//      (3)�y�z��Ʈw�̭�����ƪ�
//1.2.3 �bappsettings.json�����g��Ʈw�s�u�r��
//1.2.4 �bProgram.cs���H�̿�`�J���g�k���UŪ���s�u�r�ꪺ�A��(food panda�BUber Eats)
//      ���`�N�{������m�����n�bvar builder = WebApplication.CreateBuilder(args);�o�y����B�bvar app = builder.Build();���e
//1.2.5 �b�M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      �������`�N�`�N������ �b������O�e�Х��T�w�M�׬O�_���T���
//      �������`�N�`�N������ �b������O�e�Х��T�w�M�׬O�_���T���
//      �������`�N�`�N������ �b������O�e�Х��T�w�M�׬O�_���T���
//      (1)Add-Migration InitialCreate
//      (2)Update-database
//      ����(1)�����uInitialCreate���O�ۭq���W�١A�Y���榨�\�|�ݨ�uBuild succeeded.�v��
//      ���t�~�|�ݨ�@��Migrations����Ƨ��Ψ��ɮ׳Q�إߦb�M�פ��A�̭�������Migration�����{��
//      ����(1)�����O���榨�\�~������(2)�����O��
//      (3)��SSMS���d�ݬO�_�����\�إ߸�Ʈw�θ�ƪ�(�ثe��ƪ��S�����)

//�������ثe�ظm�X�Ӫ���Ʈw�èS���ŦX�ڭ̦b�ҫ����Ҽ��g���W�h������
//������MetadataType �u�A�Ω� UI ���ҡA�P��Ʈw�������]�w�Ȥ��ݦb��ҫ����O�ɩ� DbContext �����g�C������
//�bCode First���A�]��ҫ����O�ɤ��|�Q�л\�A�ҥH�i�H�����b��ҫ����O�ɤ����g�A���ݭn�ϥ�MetadataType�C
//���L���F�O����ҫ����O�ɻPDB First���ۮe�ʡA����ĳ�ϥ�MetadataType�Ӽ��g���ҳW�h��UI�ϥΡC
//�]���ڭ̥����bDbContext���ϥ�Fluent API�Ӽ��g�P��Ʈw�ݦ������{���A�~��T�O�b��Ʈw�إ߮ɷ|�ϥΦ��W�h�C

//1.2.6 �bDbContext���ϥ�Fluent API�bGuestBookContext�мg OnModelCreating ��k
//1.2.7 �N��Ʈw�R���A�ñN�M�פ�Migrations��Ƨ��Τ��t�ɮ׾�ӧR���C
//1.2.8 ���s����Migration�ظm��Ʈw


//��Fluent API �O Entity Framework Core ���Ѫ��@�ءu�H�{���X�覡�v�]�w��Ƽҫ��ݩʻP��ƪ��c����k�C��
//�����q�`�b�A�� DbContext ���O���A�мg OnModelCreating ��k�ӨϥΡC��


//1.3   �Ы�Initializer����إߪ�l(�ؤl)���(Seed Data)
//      �������ڭ̥i�H�b�Ыظ�Ʈw�ɴN�ЫشX����l����Ʀb�̭��H�Ѷ}�o�ɴ��դ��ΡA���o�Ӱʧ@���@�w�n���A���ݨD�өw������
//      �����������B�J�e�A�Х��N��Ʈw�R���A�ñN�M�פ�Migrations��Ƨ��Τ��t�ɮ׾�ӧR��������

//1.3.1 �ǳƺؤl�Ӥ�(SeedPhotos��Ƨ�)
//1.3.2 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��SeedData.cs�A���U�u�s�W�v�s
//1.3.3 ���gSeedData���O�����e
//      (1)���g�R�A��k Initialize(IServiceProvider serviceProvider)
//      (2)���gBook��ReBook��ƪ�����l��Ƶ{��
//      (3)���g�W�ǹϤ����{��
//      (4)�[�W using() �� �P�_��Ʈw�O�_����ƪ��{��
//1.3.4 �bProgram.cs���g�ҥ�Initializer���{��(�n�g�bvar app = builder.Build();����)
//      ���o��Initializer���@�άO�إߤ@�Ǫ�l��Ʀb��Ʈw���H�Q���աA�ҥH���@�w�n��Initializer��
//      ���`�N:��l��ƪ��Ӥ���bBookPhotos��Ƨ�����
//1.3.5 �ظm�M�סA�T�w�M�ק����ظm���\
//1.3.6 �A����M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      (1)Add-Migration InitialCreate
//      (2)Update-database
//1.3.7 ��SSMS���d�ݬO�_�����\�إ߸�Ʈw�θ�ƪ�(�ثe��ƪ��S�����)
//1.3.8 �b�s�����W������������H�إߪ�l���(�Y�S������L�����A��l��Ƥ��|�Q�إ�)
//1.3.9 �A����SSMS���d�ݸ�ƪ��O�_�����


// 2.�s�@�d���O�e�x�\��

//2.1   �s�@�۰ʥͦ���Book��ƪ�CRUD
//2.1.1 �bControllers��Ƨ��W���k����[�J�����
//2.1.2 ��ܡu�ϥ�EntityFramework�����˵���MVC����v�����U�u�[�J�v�s
//2.1.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: Book(MyModel_CodeFirst.Models)
//      ��Ƥ��e���O: GuestBookContext(MyModel_CodeFirst.Models)
//      �Ŀ� �����˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//      ����W�٧אּPostBooksController
//      ���U�u�s�W�v�s
//2.1.4 �ק�PostBooksController�A����Edit�BDelete Action
//2.1.5 �R��Edit�BDelete View�ɮ�
//2.1.6 �ק�Index Action���g�k


//2.2   ��ܥ\��
//2.2.1 �ק�A�X�e�x�e�{��Index View
//2.2.2 �NPostBooksController��Details Action��W��Display(View�]�n��W�r)
//2.2.3 �bIndex View���[�JDisplay Action���W�쵲
//2.2.4 �ק�Display View �ƪ��˦��A�ƪ��i�H�ӤH�ߦn�e�{
//      ���ƪ��i�H�ӤH�ߦn�e�{��


// 2.3   �ϥΡuViewComponent�v�ޥ���@�u�N�^�Яd�����e��ܩ�Display View�v
//      �����椸�N�n����ViewComponent���ϥΤ覡��
//2.3.1 �b�M�פ��s�WViewComponents��Ƨ�(�M�פW���k����[�J���s�W��Ƨ�)�H��m�Ҧ���ViewComponent������
//2.3.2 �bViewComponents��Ƨ����إ�VCReBooks ViewComponent(�k����[�J�����O����J�ɦW���s�W)
//2.3.3 VCReBooks class�~��ViewComponent(�`�Nusing Microsoft.AspNetCore.Mvc;)
//2.3.4 ���gInvokeAsync()��k���o�^�Яd�����
//2.3.5 �b/Views/Shared�̫إ�Components��Ƨ��A�æbComponents��Ƨ����إ�VCReBooks��Ƨ�
//2.3.6 �b/Views/Shared/Components/VCReBooks�̫إ��˵�(�k����[�J���˵�����ܡuRazor�˵��v�����U�u�[�J�v�s)
//2.3.7 �b��ܤ�����]�w�p�U
//      �˵��W��: Default
//      �d��:Empty(�S���ҫ�)
//      ���Ŀ� �إߦ������˵�
//      ���Ŀ� �ϥΪ����t�m��
//   ���`�N�G��Ƨ���View���W�٤��O�ۭq���A�ӬO���w�]���W�١A�W�w�p�U�G��
//   /Views/Shared/Components/{ComponentName}/Default.cshtml
//   /Views/{ControllerName}/Components/{ComponentName}/Default.cshtml
//2.3.8 �bDefault View�W��[�J@model IEnumerable<MyModel_CodeFirst.Models.ReBook>
//2.3.9 �̳ߦn�s��Default View�ƪ��覡
//2.3.10 �s�gDisplay View�A�[�JVCReBooks ViewComponent
//2.3.11 ����


//2.4   �d���\��
//2.4.1 �ק�Create View�A�ק�Photo���W���ɮת�����(type="file")
//2.4.2 �ק�Create View�A�N<form>�W�[ enctype="multipart/form-data" �ݩ�
//2.4.3 �[�J�e�ݮĪG�A�ϷӤ��i���w��
//2.4.4 �R��CreatedDate���
//2.4.5 �ק�Description��쪺���Ҭ�textarea
//2.4.6 �ק�Post Create Action�A�[�W�B�z�W�ǷӤ����\��
//2.4.7 ���կd���\��
//2.4.8 �bIndex View���[�J���W�ǷӤ����d������ܤ覡
//2.4.9 �bDisplay View���[�J���W�ǷӤ����d������ܤ覡
//2.4.10 �bIndex View���[�J�B�z�u�����檺�d���v��ܤ覡
//2.4.11 �bDisplay View���[�J�B�z�u�����檺�d���v��ܤ覡
//2.4.12 �bVCReBook View Component��Default View���[�J�S���^�Яd���Y����ܪ��P�_


//2.5   �^�Яd���\��
//2.5.1 �bControllers��Ƨ��W���k����[�J�����
//2.5.2 ��ܡu�ϥ�EntityFramework�����˵���MVC����v�����U�u�[�J�v�s
//2.5.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: ReBook(MyModel_CodeFirst.Models)
//      ��Ƥ��e���O: GuestBookContext(MyModel_CodeFirst.Models)
//      �Ŀ� �����˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      ���Ŀ� �ϥΪ����t�m��
//      ����W�٧אּRePostBooksController
//      ���U�u�s�W�v�s
//2.5.4 �ק�RePostBooksController�A�ȫO�dCreate Action�A�䥦�����R��
//2.5.5 �ȫO�dCreate View�ɮסA�䥦�����R��
//2.5.6 �ק� Create View
//      ���s�@�e��ݤ������^�Яd���\�ࡰ

//2.5.7 �bPostBooks\Display View���NRePostBooks\Create View�HAjax�覡Ū�J
//2.5.8 �ǻ�BookID�Ѽ�
//2.5.9 �NReBooks\Create View�]�wBookID���������(�i�bModel�[�]�i�HView���)
//2.5.10 �t�XBoostrap Modal Component��ܥXCreate�e��
//2.5.11 ���ծĪG
//2.5.12 ���J�e�����ҮM��(�pjQuery Validation)�H����Create View�����
//2.5.13 �ϥ�Callback function���s�j�w unobtrusive validation
//2.5.14 �ק�ReBooksController����Create Action�A�Ϩ�Return JSON���
//2.5.15 �bPostBooks\Display View�����g������JavaScript�{���A�HAjax�覡����s�W�^�Яd��
//2.5.16 �bReBooksController�����g��VCRebook ViewComponent���o�^�Яd����ƪ�Action
//       ���N��檺�e�X���s��type��submit�אּbutton��A���N���|�۰�Ĳ�o�e�����Ҿ���
//2.5.17 �baddReBook()��Ƥ��[�J�P�_�O�_���ҳq�L���{��
//2.5.18 ���ծĪG