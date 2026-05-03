
using SchoolManagement.Core.Model;
using System;
using System.Linq;

namespace Primary.SchoolApp.Extensions
{
    public static class PermissionExtension
    {
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page d'accueil. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page d'accueil.</param>
        /// <returns>true si l'utilisateur peut accéder à la page d'accueil ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasHomePagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 1);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des flux de trésorerie. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des flux de trésorerie.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des flux de trésorerie ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasCashFlowPagePermission(this User user)
        {
            // CashFLow Page=> 3: frais de scolarité; 4: Abonnement; 15: Approvisionnement de la caisse 16: Dépenses; 18:Fourniture scolaire
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 3 || m.ModuleId == 4 || m.ModuleId == 15 || m.ModuleId == 16 || m.ModuleId == 18);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des emplois du temps. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des emplois du temps.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des emplois du temps ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasTimeTablePagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 8);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des disciplines. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des disciplines.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des disciplines ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasDiciplinePagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 7);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des notes d'étudiant. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des notes d'étudiant.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des notes d'étudiant ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasStudentNotePagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 6);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des employés. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des employés.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des employés ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasEmployeePagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 11);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des rapports. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des rapports.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des rapports ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasReportPagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 9 || m.ModuleId == 10);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission d'accéder à la page de gestion des paramètres. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions d'accès à la page de gestion des paramètres.</param>
        /// <returns>true si l'utilisateur peut accéder à la page de gestion des paramètres ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool HasSettingPagePermission(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null || user.Modules.Count == 0) return false;
            return user.Modules.Any(m => m.ModuleId == 12);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de créer une inscription. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création d'inscription.</param>
        /// <returns>true si l'utilisateur peut créer une inscription ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateEnrolling(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 1 && m.AllowCreate == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les inscriptions. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture d'inscription.</param>
        /// <returns>true si l'utilisateur peut lire les inscriptions ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadEnrolling(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 1 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les inscriptions. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression d'inscription.</param>
        /// <returns>true si l'utilisateur peut supprimer les inscriptions ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteEnrolling(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 1 && m.AllowDelete == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de créer un étudiant. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création d'étudiant.</param>
        /// <returns>true si l'utilisateur peut créer un étudiant ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateStudent(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 2 && m.AllowCreate == true);
        }

        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les étudiants. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture d'étudiant.</param>
        /// <returns>true si l'utilisateur peut lire les étudiants ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadStudent(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 2 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les étudiants. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression d'étudiant.</param>
        /// <returns>true si l'utilisateur peut supprimer les étudiants ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteStudent(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 2 && m.AllowDelete == true);
        }
        /// <summary>
        /// permet de vérifier si un utilisateur a la permission d'enregistrer les frais de scolarité. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création de frais de scolarité.</param>
        /// <returns>true si l'utilisateur peut créer un frais de scolarité ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateTuitionFee(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 3 && m.AllowCreate == true);
        }

        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les frais de scolarité. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture de frais de scolarité.</param>
        /// <returns>true si l'utilisateur peut lire les frais de scolarité ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadTuitionFee(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 3 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les frais de scolarité. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression de frais de scolarité.</param>
        /// <returns>true si l'utilisateur peut supprimer les frais de scolarité ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteTuitionFee(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 3 && m.AllowDelete == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de créer un flux de trésorerie. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création de flux de trésorerie.</param>
        /// <returns>true si l'utilisateur peut créer un flux de trésorerie ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateCashFlow(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.UserName == "root") return true; // Admin has all permissions
            if (user.Modules == null) return false;
            return user.Modules.Any(m => (m.ModuleId == 3 && m?.AllowCreate == true) || (m.ModuleId == 15 && m?.AllowCreate == true) || (m.ModuleId == 16 && m?.AllowCreate == true) || (m.ModuleId == 18 && m?.AllowCreate == true));
        }

        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les flux de trésorerie. L'utilisateur "root" a automatiquement toutes les permissions. 
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création de discipline.</param>
        /// <returns>true si l'utilisateur peut créer une discipline ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateDicipline(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 7 && m.AllowCreate == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les disciplines. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture de discipline.</param>
        /// <returns>true si l'utilisateur peut lire une discipline ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadDicipline(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 7 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les disciplines. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression de discipline.</param>
        /// <returns>true si l'utilisateur peut supprimer une discipline ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteDicipline(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 7 && m.AllowDelete == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de créer une note d'étudiant. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création de note d'étudiant.</param>
        /// <returns>true si l'utilisateur peut créer une note d'étudiant ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateStudentNote(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 6 && m.AllowCreate == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les notes d'étudiant. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture de note d'étudiant.</param>
        /// <returns>true si l'utilisateur peut lire une note d'étudiant ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadStudentNote(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 6 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les notes d'étudiant. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression de note d'étudiant.</param>
        /// <returns>true si l'utilisateur peut supprimer une note d'étudiant ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteStudentNote(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 6 && m.AllowDelete == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de créer un employé. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création d'employé.</param>
        /// <returns>true si l'utilisateur peut créer un employé ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateEmployee(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 11 && m.AllowCreate == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les employés. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture d'employé.</param>
        /// <returns>true si l'utilisateur peut lire un employé ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadEmployee(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 11 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les employés. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression d'employé.</param>
        /// <returns>true si l'utilisateur peut supprimer un employé ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteEmployee(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 11 && m.AllowDelete == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de créer un paramètre. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de création de paramètre.</param>
        /// <returns>true si l'utilisateur peut créer un paramètre ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanCreateSetting(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 12 && m.AllowCreate == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de lire les paramètres. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de lecture de paramètre.</param>
        /// <returns>true si l'utilisateur peut lire un paramètre ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanReadSetting(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 12 && m.AllowRead == true);
        }
        /// <summary>
        /// Permet de vérifier si un utilisateur a la permission de supprimer les paramètres. L'utilisateur "root" a automatiquement toutes les permissions.
        /// </summary>
        /// <param name="user">L'utilisateur à évaluer pour les permissions de suppression de paramètre.</param>
        /// <returns>true si l'utilisateur peut supprimer un paramètre ; sinon, false.</returns>
        /// <exception cref="ArgumentNullException">Déclence une exception lorsque le paramètre utilisateur est nul.</exception>
        public static bool CanDeleteSetting(this User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (user.Modules == null) return false;
            if (user.UserName == "root") return true; // Admin has all permissions
            return user.Modules.Any(m => m.ModuleId == 12 && m.AllowDelete == true);
        }
    }
}
