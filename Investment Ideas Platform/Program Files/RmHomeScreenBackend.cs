﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Relationship_manager_administration_system
{
    class RmHomeScreenBackend
    {
        public static void clientsButtonClicked(Form formPassed, User user) {
            ClientAdmin clientAdmin = new ClientAdmin(user);
            clientAdmin.Show();
            formPassed.Hide();
        }

        public static void rmHomeScreen_Load(Label lblLoggedInRmId, User user) {
            lblLoggedInRmId.Text = "Logged In RM ID: " + user.id;
        }

        public static void purchaseIdeasButtonClicked(int rmid, Form passedForm) {
            PurchaseProducts purchaseProducts = new PurchaseProducts(rmid);
            purchaseProducts.Show();
            passedForm.Hide();
        }

        public static void gotoremoveidea(Form passedForm, int id)
        {
            RemoveIdeaScreen removeIdeaScreen = new RemoveIdeaScreen(id);
            removeIdeaScreen.Show();
            passedForm.Dispose();
            passedForm.Hide();
        }

    }
}
