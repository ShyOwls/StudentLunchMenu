using System.Text;

namespace StudentLunchMenu
{
    public partial class frmMain : Form
    {
        private const int RequiredVegetables = 2;

        public frmMain()
        {
            InitializeComponent();
        }

        // Shared by all vegetable checkboxes: blocks selecting more than two.
        private void Veggie_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender is not CheckBox changed || !changed.Checked)
                return;

            int count = grpVeggies.Controls.OfType<CheckBox>().Count(c => c.Checked);

            if (count > RequiredVegetables)
            {
                changed.Checked = false;
                MessageBox.Show(
                    $"You can only select {RequiredVegetables} vegetables.",
                    "Too many vegetables",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            string name = txtStudentName.Text.Trim();
            RadioButton? entree = SelectedRadio(grpMeats);
            RadioButton? drink = SelectedRadio(grpDrinks);
            RadioButton? dessert = SelectedRadio(grpDessert);
            List<CheckBox> veggies = grpVeggies.Controls.OfType<CheckBox>()
                .Where(c => c.Checked)
                .ToList();

            var problems = new List<string>();
            if (name.Length == 0) problems.Add("Enter the student's name.");
            if (entree is null) problems.Add("Choose an entrée.");
            if (veggies.Count != RequiredVegetables) problems.Add($"Choose {RequiredVegetables} vegetables.");
            if (drink is null) problems.Add("Choose a drink.");
            if (dessert is null) problems.Add("Choose a fruit or dessert.");

            if (problems.Count > 0)
            {
                MessageBox.Show(
                    "Please fix the following:\n\n" + string.Join("\n", problems),
                    "Incomplete order",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var lunch = new StringBuilder();
            lunch.AppendLine($"{name}'s lunch menu:");
            lunch.AppendLine($"Entrée: {entree!.Text}");
            foreach (CheckBox veggie in veggies)
                lunch.AppendLine($"Vegetable: {veggie.Text}");
            lunch.AppendLine($"Drink: {drink!.Text}");
            lunch.AppendLine($"Dessert: {dessert!.Text}");

            MessageBox.Show(lunch.ToString(), "Student Lunch Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object? sender, EventArgs e)
        {
            txtStudentName.Clear();

            foreach (GroupBox group in new[] { grpMeats, grpVeggies, grpDrinks, grpDessert })
            {
                foreach (RadioButton radio in group.Controls.OfType<RadioButton>())
                    radio.Checked = false;
                foreach (CheckBox check in group.Controls.OfType<CheckBox>())
                    check.Checked = false;
            }

            txtStudentName.Focus();
        }

        private static RadioButton? SelectedRadio(GroupBox group) =>
            group.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
    }
}
