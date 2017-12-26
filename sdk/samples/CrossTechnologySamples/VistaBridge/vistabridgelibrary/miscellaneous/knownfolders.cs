using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Microsoft.SDK.Samples.VistaBridge.Library
{
    public enum KnownFolderFindMode : int
    {
        ExactMatch = 0,
        NearestParentMatch = ExactMatch + 1
    };

    public class KnownFolders
    {
        [Guid("8BE2D872-86AA-4d47-B776-32CCA40C7018"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IKnownFolderManager
        {
            void FolderIdFromCsidl(int Csidl, [Out] out Guid knownFolderID);
            void FolderIdToCsidl(
                [In, MarshalAs(UnmanagedType.LPStruct)] Guid id, 
                [Out] out int Csidl);

            void GetFolderIds();
            void GetFolder(
                [In, MarshalAs(UnmanagedType.LPStruct)] Guid id, 
                [Out, MarshalAs(UnmanagedType.Interface)] out KnownFolder.IKnownFolder knownFolder);

            void GetFolderByName(string canonicalName, [Out, MarshalAs(UnmanagedType.Interface)] out KnownFolder.IKnownFolder knowFolder);
            void RegisterFolder();  
            void UnregisterFolder(); 
            void FindFolderFromPath([In, MarshalAs(UnmanagedType.LPWStr)] string path, [In] KnownFolderFindMode mode, [Out, MarshalAs(UnmanagedType.Interface)] out KnownFolder.IKnownFolder knownFolder);
            void FindFolderFromIDList(); 
            void Redirect(); 
        }

        [ComImport, Guid("4df0c730-df9d-4ae3-9153-aa6b82e9795a")]
        internal class KnownFolderManager
        {
        }

        static IKnownFolderManager _knownFolderManager = (IKnownFolderManager)new KnownFolderManager();

        public static KnownFolder GetKnownFolder(int csidl)
        {
            Guid knownFolderID;
            _knownFolderManager.FolderIdFromCsidl(csidl, out knownFolderID);
            KnownFolder.IKnownFolder knowFolderInterface;
            _knownFolderManager.GetFolder(knownFolderID, out knowFolderInterface);
            return new KnownFolder(knowFolderInterface);
        }

        public static KnownFolder GetKnownFolder(Guid knownFolderID)
        {
            KnownFolder.IKnownFolder knowFolderInterface;
            _knownFolderManager.GetFolder(knownFolderID, out knowFolderInterface);
            return new KnownFolder(knowFolderInterface);
        }

        public static KnownFolder GetKnownFolder(string canonicalName)
        {
            KnownFolder.IKnownFolder knowFolderInterface;
            _knownFolderManager.GetFolderByName(canonicalName, out knowFolderInterface);
            return new KnownFolder(knowFolderInterface);
        }

        public static KnownFolder FindFolderFromPath(string path, KnownFolderFindMode mode)
        {
            KnownFolder.IKnownFolder knowFolderInterface;
            _knownFolderManager.FindFolderFromPath(path, mode, out knowFolderInterface);
            return new KnownFolder(knowFolderInterface);
        }

        public static int GetCsidl(Guid knownFolderID)
        {
            int csidl;
            _knownFolderManager.FolderIdToCsidl(knownFolderID, out csidl);
            return csidl;
        }

        private static string GetPath(Guid knownFolderID)
        {
            IntPtr pointerToPath = IntPtr.Zero;
            string path;
            try
            {
                KnownFolder.IKnownFolder knowFolderInterface;
                _knownFolderManager.GetFolder(knownFolderID, out knowFolderInterface);
                knowFolderInterface.GetPath(0, out pointerToPath);
                path = Marshal.PtrToStringUni(pointerToPath);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pointerToPath);
            }
            return path;
        }

        public static string Desktop 
        { 
            get { return GetPath(KnownFolderIdentifiers.Desktop); } 
        }
        public static string Fonts 
        { 
            get { return GetPath(KnownFolderIdentifiers.Fonts); } 
        }
        public static string Startup 
        { 
            get { return GetPath(KnownFolderIdentifiers.Startup); } 
        }
        public static string Programs 
        { 
            get { return GetPath(KnownFolderIdentifiers.Programs); } 
        }
        public static string StartMenu 
        { 
            get { return GetPath(KnownFolderIdentifiers.StartMenu); } 
        }
        public static string Recent 
        { 
            get { return GetPath(KnownFolderIdentifiers.Recent); } 
        }
        public static string SendTo 
        { 
            get { return GetPath(KnownFolderIdentifiers.SendTo); } 
        }
        public static string Documents 
        { 
            get { return GetPath(KnownFolderIdentifiers.Documents); } 
        }
        public static string Favorites 
        { 
            get { return GetPath(KnownFolderIdentifiers.Favorites); } 
        }
        public static string NetHood 
        { 
            get { return GetPath(KnownFolderIdentifiers.NetHood); } 
        }
        public static string PrintHood 
        { 
            get { return GetPath(KnownFolderIdentifiers.PrintHood); } 
        }
        public static string Templates 
        { 
            get { return GetPath(KnownFolderIdentifiers.Templates); } 
        }
        public static string CommonStartup 
        { 
            get { return GetPath(KnownFolderIdentifiers.CommonStartup); } 
        }
        public static string CommonPrograms 
        { 
            get { return GetPath(KnownFolderIdentifiers.CommonPrograms); } 
        }
        public static string CommonStartMenu 
        { 
            get { return GetPath(KnownFolderIdentifiers.CommonStartMenu); } 
        }
        public static string PublicDesktop 
        { 
            get { return GetPath(KnownFolderIdentifiers.PublicDesktop); } 
        }
        public static string ProgramData 
        { 
            get { return GetPath(KnownFolderIdentifiers.ProgramData); } 
        }
        public static string CommonTemplates 
        { 
            get { return GetPath(KnownFolderIdentifiers.CommonTemplates); } 
        }
        public static string PublicDocuments 
        { 
            get { return GetPath(KnownFolderIdentifiers.PublicDocuments); } 
        }
        public static string RoamingAppData 
        { 
            get { return GetPath(KnownFolderIdentifiers.RoamingAppData); } 
        }
        public static string LocalAppData 
        { 
            get { return GetPath(KnownFolderIdentifiers.LocalAppData); } 
        }
        public static string LocalAppDataLow 
        { 
            get { return GetPath(KnownFolderIdentifiers.LocalAppDataLow); } 
        }
        public static string InternetCache 
        { 
            get { return GetPath(KnownFolderIdentifiers.InternetCache); } 
        }
        public static string Cookies 
        { get { return GetPath(KnownFolderIdentifiers.Cookies); } }
        public static string History 
        { get { return GetPath(KnownFolderIdentifiers.History); } }
        public static string System 
        { get { return GetPath(KnownFolderIdentifiers.System); } }
        public static string SystemX86 
        { get { return GetPath(KnownFolderIdentifiers.SystemX86); } }
        public static string Windows 
        { get { return GetPath(KnownFolderIdentifiers.Windows); } }
        public static string Profile 
        { get { return GetPath(KnownFolderIdentifiers.Profile); } }
        public static string Pictures 
        { get { return GetPath(KnownFolderIdentifiers.Pictures); } }
        public static string ProgramFilesX86 
        { get { return GetPath(KnownFolderIdentifiers.ProgramFilesX86); } }
        public static string ProgramFilesCommonX86 
        { get { return GetPath(KnownFolderIdentifiers.ProgramFilesCommonX86); } }
        public static string ProgramFilesX64 
        { get { return GetPath(KnownFolderIdentifiers.ProgramFilesX64); } }
        public static string ProgramFilesCommonX64 
        { get { return GetPath(KnownFolderIdentifiers.ProgramFilesCommonX64); } }
        public static string ProgramFiles { get { return GetPath(KnownFolderIdentifiers.ProgramFiles); } }
        public static string ProgramFilesCommon { get { return GetPath(KnownFolderIdentifiers.ProgramFilesCommon); } }
        public static string AdminTools { get { return GetPath(KnownFolderIdentifiers.AdminTools); } }
        public static string CommonAdminTools { get { return GetPath(KnownFolderIdentifiers.CommonAdminTools); } }
        public static string Music { get { return GetPath(KnownFolderIdentifiers.Music); } }
        public static string Videos { get { return GetPath(KnownFolderIdentifiers.Videos); } }
        public static string PublicPictures { get { return GetPath(KnownFolderIdentifiers.PublicPictures); } }
        public static string PublicMusic { get { return GetPath(KnownFolderIdentifiers.PublicMusic); } }
        public static string PublicVideos { get { return GetPath(KnownFolderIdentifiers.PublicVideos); } }
        public static string ResourceDir { get { return GetPath(KnownFolderIdentifiers.ResourceDir); } }
        public static string LocalizedResourcesDir { get { return GetPath(KnownFolderIdentifiers.LocalizedResourcesDir); } }
        public static string CommonOEMLinks { get { return GetPath(KnownFolderIdentifiers.CommonOEMLinks); } }
        public static string CDBurning { get { return GetPath(KnownFolderIdentifiers.CDBurning); } }
        public static string UserProfiles { get { return GetPath(KnownFolderIdentifiers.UserProfiles); } }
        public static string Public { get { return GetPath(KnownFolderIdentifiers.Public); } }
        public static string Downloads { get { return GetPath(KnownFolderIdentifiers.Downloads); } }
        public static string PublicDownloads { get { return GetPath(KnownFolderIdentifiers.PublicDownloads); } }
        public static string SavedSearches { get { return GetPath(KnownFolderIdentifiers.SavedSearches); } }
        public static string QuickLaunch { get { return GetPath(KnownFolderIdentifiers.QuickLaunch); } }
        public static string Contacts { get { return GetPath(KnownFolderIdentifiers.Contacts); } }
        public static string SidebarParts { get { return GetPath(KnownFolderIdentifiers.SidebarParts); } }
        public static string SidebarDefaultParts { get { return GetPath(KnownFolderIdentifiers.SidebarDefaultParts); } }
        public static string PublicGameTasks { get { return GetPath(KnownFolderIdentifiers.PublicGameTasks); } }
        public static string GameTasks { get { return GetPath(KnownFolderIdentifiers.GameTasks); } }
        public static string SavedGames { get { return GetPath(KnownFolderIdentifiers.SavedGames); } }
        public static string Links { get { return GetPath(KnownFolderIdentifiers.Links); } }
    }

    public class KnownFolderIdentifiers
    {
        public static Guid Computer = new Guid(0x0AC0837C, 0xBBF8, 0x452A, 0x85, 0x0D, 0x79, 0xD0, 0x8E, 0x66, 0x7C, 0xA7);
        public static Guid Conflict = new Guid(0x4bfefb45, 0x347d, 0x4006, 0xa5, 0xbe, 0xac, 0x0c, 0xb0, 0x56, 0x71, 0x92);
        public static Guid ControlPanel = new Guid(0x82A74AEB, 0xAEB4, 0x465C, 0xA0, 0x14, 0xD0, 0x97, 0xEE, 0x34, 0x6D, 0x63);
        public static Guid Desktop = new Guid(0xB4BFCC3A, 0xDB2C, 0x424C, 0xB0, 0x29, 0x7F, 0xE9, 0x9A, 0x87, 0xC6, 0x41);
        public static Guid Internet = new Guid(0x4D9F7874, 0x4E0C, 0x4904, 0x96, 0x7B, 0x40, 0xB0, 0xD2, 0x0C, 0x3E, 0x4B);
        public static Guid Network = new Guid(0xD20BEEC4, 0x5CA8, 0x4905, 0xAE, 0x3B, 0xBF, 0x25, 0x1E, 0xA0, 0x9B, 0x53);
        public static Guid Printers = new Guid(0x76FC4E2D, 0xD6AD, 0x4519, 0xA6, 0x63, 0x37, 0xBD, 0x56, 0x06, 0x81, 0x85);
        public static Guid SyncManager = new Guid(0x43668BF8, 0xC14E, 0x49B2, 0x97, 0xC9, 0x74, 0x77, 0x84, 0xD7, 0x84, 0xB7);
        public static Guid Connections = new Guid(0x6F0CD92B, 0x2E97, 0x45D1, 0x88, 0xFF, 0xB0, 0xD1, 0x86, 0xB8, 0xDE, 0xDD);
        public static Guid SyncSetup = new Guid(0xf214138, 0xb1d3, 0x4a90, 0xbb, 0xa9, 0x27, 0xcb, 0xc0, 0xc5, 0x38, 0x9a);
        public static Guid SyncResults = new Guid(0x289a9a43, 0xbe44, 0x4057, 0xa4, 0x1b, 0x58, 0x7a, 0x76, 0xd7, 0xe7, 0xf9);
        public static Guid RecycleBin = new Guid(0xB7534046, 0x3ECB, 0x4C18, 0xBE, 0x4E, 0x64, 0xCD, 0x4C, 0xB7, 0xD6, 0xAC);
        public static Guid Fonts = new Guid(0xFD228CB7, 0xAE11, 0x4AE3, 0x86, 0x4C, 0x16, 0xF3, 0x91, 0x0A, 0xB8, 0xFE);
        public static Guid Startup = new Guid(0xB97D20BB, 0xF46A, 0x4C97, 0xBA, 0x10, 0x5E, 0x36, 0x08, 0x43, 0x08, 0x54);
        public static Guid Programs = new Guid(0xA77F5D77, 0x2E2B, 0x44C3, 0xA6, 0xA2, 0xAB, 0xA6, 0x01, 0x05, 0x4A, 0x51);
        public static Guid StartMenu = new Guid(0x625B53C3, 0xAB48, 0x4EC1, 0xBA, 0x1F, 0xA1, 0xEF, 0x41, 0x46, 0xFC, 0x19);
        public static Guid Recent = new Guid(0xAE50C081, 0xEBD2, 0x438A, 0x86, 0x55, 0x8A, 0x09, 0x2E, 0x34, 0x98, 0x7A);
        public static Guid SendTo = new Guid(0x8983036C, 0x27C0, 0x404B, 0x8F, 0x08, 0x10, 0x2D, 0x10, 0xDC, 0xFD, 0x74);
        public static Guid Documents = new Guid(0xFDD39AD0, 0x238F, 0x46AF, 0xAD, 0xB4, 0x6C, 0x85, 0x48, 0x03, 0x69, 0xC7);
        public static Guid Favorites = new Guid(0x1777F761, 0x68AD, 0x4D8A, 0x87, 0xBD, 0x30, 0xB7, 0x59, 0xFA, 0x33, 0xDD);
        public static Guid NetHood = new Guid(0xC5ABBF53, 0xE17F, 0x4121, 0x89, 0x00, 0x86, 0x62, 0x6F, 0xC2, 0xC9, 0x73);
        public static Guid PrintHood = new Guid(0x9274BD8D, 0xCFD1, 0x41C3, 0xB3, 0x5E, 0xB1, 0x3F, 0x55, 0xA7, 0x58, 0xF4);
        public static Guid Templates = new Guid(0xA63293E8, 0x664E, 0x48DB, 0xA0, 0x79, 0xDF, 0x75, 0x9E, 0x05, 0x09, 0xF7);
        public static Guid CommonStartup = new Guid(0x82A5EA35, 0xD9CD, 0x47C5, 0x96, 0x29, 0xE1, 0x5D, 0x2F, 0x71, 0x4E, 0x6E);
        public static Guid CommonPrograms = new Guid(0x0139D44E, 0x6AFE, 0x49F2, 0x86, 0x90, 0x3D, 0xAF, 0xCA, 0xE6, 0xFF, 0xB8);
        public static Guid CommonStartMenu = new Guid(0xA4115719, 0xD62E, 0x491D, 0xAA, 0x7C, 0xE7, 0x4B, 0x8B, 0xE3, 0xB0, 0x67);
        public static Guid PublicDesktop = new Guid(0xC4AA340D, 0xF20F, 0x4863, 0xAF, 0xEF, 0xF8, 0x7E, 0xF2, 0xE6, 0xBA, 0x25);
        public static Guid ProgramData = new Guid(0x62AB5D82, 0xFDC1, 0x4DC3, 0xA9, 0xDD, 0x07, 0x0D, 0x1D, 0x49, 0x5D, 0x97);
        public static Guid CommonTemplates = new Guid(0xB94237E7, 0x57AC, 0x4347, 0x91, 0x51, 0xB0, 0x8C, 0x6C, 0x32, 0xD1, 0xF7);
        public static Guid PublicDocuments = new Guid(0xED4824AF, 0xDCE4, 0x45A8, 0x81, 0xE2, 0xFC, 0x79, 0x65, 0x08, 0x36, 0x34);
        public static Guid RoamingAppData = new Guid(0x3EB685DB, 0x65F9, 0x4CF6, 0xA0, 0x3A, 0xE3, 0xEF, 0x65, 0x72, 0x9F, 0x3D);
        public static Guid LocalAppData = new Guid(0xF1B32785, 0x6FBA, 0x4FCF, 0x9D, 0x55, 0x7B, 0x8E, 0x7F, 0x15, 0x70, 0x91);
        public static Guid LocalAppDataLow = new Guid(0xA520A1A4, 0x1780, 0x4FF6, 0xBD, 0x18, 0x16, 0x73, 0x43, 0xC5, 0xAF, 0x16);
        public static Guid InternetCache = new Guid(0x352481E8, 0x33BE, 0x4251, 0xBA, 0x85, 0x60, 0x07, 0xCA, 0xED, 0xCF, 0x9D);
        public static Guid Cookies = new Guid(0x2B0F765D, 0xC0E9, 0x4171, 0x90, 0x8E, 0x08, 0xA6, 0x11, 0xB8, 0x4F, 0xF6);
        public static Guid History = new Guid(0xD9DC8A3B, 0xB784, 0x432E, 0xA7, 0x81, 0x5A, 0x11, 0x30, 0xA7, 0x59, 0x63);
        public static Guid System = new Guid(0x1AC14E77, 0x02E7, 0x4E5D, 0xB7, 0x44, 0x2E, 0xB1, 0xAE, 0x51, 0x98, 0xB7);
        public static Guid SystemX86 = new Guid(0xD65231B0, 0xB2F1, 0x4857, 0xA4, 0xCE, 0xA8, 0xE7, 0xC6, 0xEA, 0x7D, 0x27);
        public static Guid Windows = new Guid(0xF38BF404, 0x1D43, 0x42F2, 0x93, 0x05, 0x67, 0xDE, 0x0B, 0x28, 0xFC, 0x23);
        public static Guid Profile = new Guid(0x5E6C858F, 0x0E22, 0x4760, 0x9A, 0xFE, 0xEA, 0x33, 0x17, 0xB6, 0x71, 0x73);
        public static Guid Pictures = new Guid(0x33E28130, 0x4E1E, 0x4676, 0x83, 0x5A, 0x98, 0x39, 0x5C, 0x3B, 0xC3, 0xBB);
        public static Guid ProgramFilesX86 = new Guid(0x7C5A40EF, 0xA0FB, 0x4BFC, 0x87, 0x4A, 0xC0, 0xF2, 0xE0, 0xB9, 0xFA, 0x8E);
        public static Guid ProgramFilesCommonX86 = new Guid(0xDE974D24, 0xD9C6, 0x4D3E, 0xBF, 0x91, 0xF4, 0x45, 0x51, 0x20, 0xB9, 0x17);
        public static Guid ProgramFilesX64 = new Guid(0x6d809377, 0x6af0, 0x444b, 0x89, 0x57, 0xa3, 0x77, 0x3f, 0x02, 0x20, 0x0e);
        public static Guid ProgramFilesCommonX64 = new Guid(0x6365d5a7, 0xf0d, 0x45e5, 0x87, 0xf6, 0xd, 0xa5, 0x6b, 0x6a, 0x4f, 0x7d);
        public static Guid ProgramFiles = new Guid(0x905e63b6, 0xc1bf, 0x494e, 0xb2, 0x9c, 0x65, 0xb7, 0x32, 0xd3, 0xd2, 0x1a);
        public static Guid ProgramFilesCommon = new Guid(0xF7F1ED05, 0x9F6D, 0x47A2, 0xAA, 0xAE, 0x29, 0xD3, 0x17, 0xC6, 0xF0, 0x66);
        public static Guid AdminTools = new Guid(0x724EF170, 0xA42D, 0x4FEF, 0x9F, 0x26, 0xB6, 0x0E, 0x84, 0x6F, 0xBA, 0x4F);
        public static Guid CommonAdminTools = new Guid(0xD0384E7D, 0xBAC3, 0x4797, 0x8F, 0x14, 0xCB, 0xA2, 0x29, 0xB3, 0x92, 0xB5);
        public static Guid Music = new Guid(0x4BD8D571, 0x6D19, 0x48D3, 0xBE, 0x97, 0x42, 0x22, 0x20, 0x08, 0x0E, 0x43);
        public static Guid Videos = new Guid(0x18989B1D, 0x99B5, 0x455B, 0x84, 0x1C, 0xAB, 0x7C, 0x74, 0xE4, 0xDD, 0xFC);
        public static Guid PublicPictures = new Guid(0xB6EBFB86, 0x6907, 0x413C, 0x9A, 0xF7, 0x4F, 0xC2, 0xAB, 0xF0, 0x7C, 0xC5);
        public static Guid PublicMusic = new Guid(0x3214FAB5, 0x9757, 0x4298, 0xBB, 0x61, 0x92, 0xA9, 0xDE, 0xAA, 0x44, 0xFF);
        public static Guid PublicVideos = new Guid(0x2400183A, 0x6185, 0x49FB, 0xA2, 0xD8, 0x4A, 0x39, 0x2A, 0x60, 0x2B, 0xA3);
        public static Guid ResourceDir = new Guid(0x8AD10C31, 0x2ADB, 0x4296, 0xA8, 0xF7, 0xE4, 0x70, 0x12, 0x32, 0xC9, 0x72);
        public static Guid LocalizedResourcesDir = new Guid(0x2A00375E, 0x224C, 0x49DE, 0xB8, 0xD1, 0x44, 0x0D, 0xF7, 0xEF, 0x3D, 0xDC);
        public static Guid CommonOEMLinks = new Guid(0xC1BAE2D0, 0x10DF, 0x4334, 0xBE, 0xDD, 0x7A, 0xA2, 0x0B, 0x22, 0x7A, 0x9D);
        public static Guid CDBurning = new Guid(0x9E52AB10, 0xF80D, 0x49DF, 0xAC, 0xB8, 0x43, 0x30, 0xF5, 0x68, 0x78, 0x55);
        public static Guid UserProfiles = new Guid(0x0762D272, 0xC50A, 0x4BB0, 0xA3, 0x82, 0x69, 0x7D, 0xCD, 0x72, 0x9B, 0x80);
        public static Guid Playlists = new Guid(0xDE92C1C7, 0x837F, 0x4F69, 0xA3, 0xBB, 0x86, 0xE6, 0x31, 0x20, 0x4A, 0x23);
        public static Guid SamplePlaylists = new Guid(0x15CA69B3, 0x30EE, 0x49C1, 0xAC, 0xE1, 0x6B, 0x5E, 0xC3, 0x72, 0xAF, 0xB5);
        public static Guid SampleMusic = new Guid(0xB250C668, 0xF57D, 0x4EE1, 0xA6, 0x3C, 0x29, 0x0E, 0xE7, 0xD1, 0xAA, 0x1F);
        public static Guid SamplePictures = new Guid(0xC4900540, 0x2379, 0x4C75, 0x84, 0x4B, 0x64, 0xE6, 0xFA, 0xF8, 0x71, 0x6B);
        public static Guid SampleVideos = new Guid(0x859EAD94, 0x2E85, 0x48AD, 0xA7, 0x1A, 0x09, 0x69, 0xCB, 0x56, 0xA6, 0xCD);
        public static Guid PhotoAlbums = new Guid(0x69D2CF90, 0xFC33, 0x4FB7, 0x9A, 0x0C, 0xEB, 0xB0, 0xF0, 0xFC, 0xB4, 0x3C);
        public static Guid Public = new Guid(0xDFDF76A2, 0xC82A, 0x4D63, 0x90, 0x6A, 0x56, 0x44, 0xAC, 0x45, 0x73, 0x85);
        public static Guid ChangeRemovePrograms = new Guid(0xdf7266ac, 0x9274, 0x4867, 0x8d, 0x55, 0x3b, 0xd6, 0x61, 0xde, 0x87, 0x2d);
        public static Guid AppUpdates = new Guid(0xa305ce99, 0xf527, 0x492b, 0x8b, 0x1a, 0x7e, 0x76, 0xfa, 0x98, 0xd6, 0xe4);
        public static Guid AddNewPrograms = new Guid(0xde61d971, 0x5ebc, 0x4f02, 0xa3, 0xa9, 0x6c, 0x82, 0x89, 0x5e, 0x5c, 0x04);
        public static Guid Downloads = new Guid(0x374de290, 0x123f, 0x4565, 0x91, 0x64, 0x39, 0xc4, 0x92, 0x5e, 0x46, 0x7b);
        public static Guid PublicDownloads = new Guid(0x3d644c9b, 0x1fb8, 0x4f30, 0x9b, 0x45, 0xf6, 0x70, 0x23, 0x5f, 0x79, 0xc0);
        public static Guid SavedSearches = new Guid(0x7d1d3a04, 0xdebb, 0x4115, 0x95, 0xcf, 0x2f, 0x29, 0xda, 0x29, 0x20, 0xda);
        public static Guid QuickLaunch = new Guid(0x52a4f021, 0x7b75, 0x48a9, 0x9f, 0x6b, 0x4b, 0x87, 0xa2, 0x10, 0xbc, 0x8f);
        public static Guid Contacts = new Guid(0x56784854, 0xc6cb, 0x462b, 0x81, 0x69, 0x88, 0xe3, 0x50, 0xac, 0xb8, 0x82);
        public static Guid SidebarParts = new Guid(0xa75d362e, 0x50fc, 0x4fb7, 0xac, 0x2c, 0xa8, 0xbe, 0xaa, 0x31, 0x44, 0x93);
        public static Guid SidebarDefaultParts = new Guid(0x7b396e54, 0x9ec5, 0x4300, 0xbe, 0xa, 0x24, 0x82, 0xeb, 0xae, 0x1a, 0x26);
        public static Guid TreeProperties = new Guid(0x5b3749ad, 0xb49f, 0x49c1, 0x83, 0xeb, 0x15, 0x37, 0x0f, 0xbd, 0x48, 0x82);
        public static Guid PublicGameTasks = new Guid(0xdebf2536, 0xe1a8, 0x4c59, 0xb6, 0xa2, 0x41, 0x45, 0x86, 0x47, 0x6a, 0xea);
        public static Guid GameTasks = new Guid(0x54fae61, 0x4dd8, 0x4787, 0x80, 0xb6, 0x9, 0x2, 0x20, 0xc4, 0xb7, 0x0);
        public static Guid SavedGames = new Guid(0x4c5c32ff, 0xbb9d, 0x43b0, 0xb5, 0xb4, 0x2d, 0x72, 0xe5, 0x4e, 0xaa, 0xa4);
        public static Guid Games = new Guid(0xcac52c1a, 0xb53d, 0x4edc, 0x92, 0xd7, 0x6b, 0x2e, 0x8a, 0xc1, 0x94, 0x34);
        public static Guid RecordedTV = new Guid(0xbd85e001, 0x112e, 0x431e, 0x98, 0x3b, 0x7b, 0x15, 0xac, 0x09, 0xff, 0xf1);
        public static Guid SearchMapi = new Guid(0x98ec0e18, 0x2098, 0x4d44, 0x86, 0x44, 0x66, 0x97, 0x93, 0x15, 0xa2, 0x81);
        public static Guid SearchCsc = new Guid(0xee32e446, 0x31ca, 0x4aba, 0x81, 0x4f, 0xa5, 0xeb, 0xd2, 0xfd, 0x6d, 0x5e);
        public static Guid Links = new Guid(0xbfb9d5e0, 0xc6a9, 0x404c, 0xb2, 0xb2, 0xae, 0x6d, 0xb6, 0xaf, 0x49, 0x68);
        public static Guid UsersFiles = new Guid(0xf3ce0f7c, 0x4901, 0x4acc, 0x86, 0x48, 0xd5, 0xd4, 0x4b, 0x04, 0xef, 0x8f);
        public static Guid SearchHome = new Guid(0x190337d1, 0xb8ca, 0x4121, 0xa6, 0x39, 0x6d, 0x47, 0x2d, 0x16, 0x97, 0x2a);
        public static Guid OriginalImages = new Guid(0x2C36C0AA, 0x5812, 0x4b87, 0xbf, 0xd0, 0x4c, 0xd0, 0xdf, 0xb1, 0x9b, 0x39);
    }

    public enum KnownFolderCategory
    {
        Virtual = 1,
        Fixed = 2,
        Common = 3,
        PerUser = 4
    }

    public enum KnownFolderRetrievalOptions
    {
        Create = 0x00008000,
        DontVerify = 0x00004000,
        DontUnexpand = 0x00002000,
        NoAlias = 0x00001000,
        Init = 0x00000800,
        DefaultPath = 0x00000400,
        NotParentRelative = 0x00000200
    }

    public enum KnownFolderRedirectionCapabilities
    {
        AllowAll = 0xff,
        Redirectable = 0x1,
        DenyAll = 0xfff00,
        DenyPolicyRedirected = 0x100,
        DenyPolicy = 0x200,
        DenyPermissions = 0x400
    }

    public enum KnownFolderDefinitionFlags
    {
        LocalRedirectOnly = 0x2,
        Roamable = 0x4,
        Precreate = 0x8
    }

    public struct KnownFolderDefinition
    {
        public KnownFolderCategory Category;
        public string Name;
        public string Description;
        public Guid ParentID;
        public string RelativePath;
        public string ParsingName;
        public string Tooltip;
        public string LocalizedName;
        public string Icon;
        public string Security;
        public UInt32 Attributes;
        public KnownFolderDefinitionFlags DefinitionFlags;
        public Guid FolderTypeID;
    }

    public class KnownFolder
    {
        [ComImport, Guid("3AA7AF7E-9B36-420c-A8E3-F77D4674A488"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IKnownFolder
        {
            void GetId([Out] out Guid Id);
            void GetCategory([Out] out KnownFolderCategory category);
            void GetShellItem(
                   KnownFolderRetrievalOptions retrievalOptions,
                   [MarshalAs(UnmanagedType.LPStruct)] Guid interfaceGuid,
                   [Out, MarshalAs(UnmanagedType.IUnknown)] out object shellItem);
            void GetPath(
                KnownFolderRetrievalOptions retrievalOptions, 
                [Out] out IntPtr path);

            void SetPath(KnownFolderRetrievalOptions retrievalOptions, string path);
            void GetIDList(KnownFolderRetrievalOptions retrievalOptions, 
                [Out] out IntPtr itemIdentifierListPointer);
            void GetFolderType([Out, MarshalAs(UnmanagedType.LPStruct)] out Guid folderTypeID);
            void GetRedirectionCapabilities([Out] out KnownFolderRedirectionCapabilities redirectionCapabilities);
            void GetFolderDefinition([Out, MarshalAs(UnmanagedType.Struct)] out InternalKnownFolderDefinition definition);
        }

        IKnownFolder _knownFolder = null;

        internal KnownFolder(IKnownFolder knownFolder)
        {
            _knownFolder = knownFolder;
        }

        public string Path
        {
            get { return GetPath(0); }
            set { SetPath(value, 0); }
        }

        public string GetPath(KnownFolderRetrievalOptions options)
        {
            IntPtr pointerToPath = IntPtr.Zero;
            string path;
            try
            {
                _knownFolder.GetPath(options, out pointerToPath);
                path = Marshal.PtrToStringUni(pointerToPath);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pointerToPath);
            }
            return path;
        }

        public void SetPath(string path, KnownFolderRetrievalOptions options)
        {
            _knownFolder.SetPath(options, path);
        }

        public Guid Id
        {
            get
            {
                Guid id;
                _knownFolder.GetId(out id);
                return id;
            }
        }

        public Guid FolderType
        {
            get
            {
                Guid type;
                _knownFolder.GetFolderType(out type);
                return type;
            }
        }
        public KnownFolderCategory Category
        {
            get
            {
                KnownFolderCategory category;
                _knownFolder.GetCategory(out category);
                return category;
            }
        }
        public KnownFolderRedirectionCapabilities RedirectionCapabilities
        {
            get
            {
                KnownFolderRedirectionCapabilities redirectionCapabilities;
                _knownFolder.GetRedirectionCapabilities(out redirectionCapabilities);
                return redirectionCapabilities;
            }
        }

        internal struct InternalKnownFolderDefinition
        {
            internal KnownFolderCategory Category;
            internal IntPtr pszName;
            internal IntPtr pszDescription;
            internal Guid ParentID;
            internal IntPtr pszRelativePath;
            internal IntPtr pszParsingName;
            internal IntPtr pszTooltip;
            internal IntPtr pszLocalizedName;
            internal IntPtr pszIcon;
            internal IntPtr pszSecurity;
            internal UInt32 dwAttributes;
            internal KnownFolderDefinitionFlags DefinitionFlags;
            internal Guid FolderTypeID;
        }

        // This is not a small operation so it should be a method.
        public KnownFolderDefinition GetDefinition()
        {
            InternalKnownFolderDefinition internalDefinition;
            KnownFolderDefinition definition = new KnownFolderDefinition();
            _knownFolder.GetFolderDefinition(out internalDefinition);
            try
            {
                definition.Category = internalDefinition.Category;
                definition.Name = Marshal.PtrToStringUni(
                    internalDefinition.pszName);

                definition.Description = Marshal.PtrToStringUni( 
                    internalDefinition.pszDescription);

                definition.ParentID = internalDefinition.ParentID;
                definition.ParsingName = Marshal.PtrToStringUni( 
                    internalDefinition.pszParsingName);

                definition.Tooltip = Marshal.PtrToStringUni(
                    internalDefinition.pszTooltip);
                definition.LocalizedName = Marshal.PtrToStringUni(internalDefinition.pszLocalizedName);
                definition.Icon = Marshal.PtrToStringUni(
                    internalDefinition.pszIcon);
                definition.Security = Marshal.PtrToStringUni(
                    internalDefinition.pszSecurity);
                definition.Attributes = internalDefinition.dwAttributes;
                definition.DefinitionFlags = internalDefinition.DefinitionFlags;
                definition.FolderTypeID = internalDefinition.FolderTypeID;
            }
            finally
            {
                Marshal.FreeCoTaskMem(internalDefinition.pszName);
                Marshal.FreeCoTaskMem(internalDefinition.pszDescription);
                Marshal.FreeCoTaskMem(internalDefinition.pszRelativePath);
                Marshal.FreeCoTaskMem(internalDefinition.pszParsingName);
                Marshal.FreeCoTaskMem(internalDefinition.pszTooltip);
                Marshal.FreeCoTaskMem(internalDefinition.pszLocalizedName);
                Marshal.FreeCoTaskMem(internalDefinition.pszIcon);
                Marshal.FreeCoTaskMem(internalDefinition.pszSecurity);
            }
            return definition;
        }
    }
}
