using CodeFramework.Editor.EditorWindows;
using UnityEngine.UIElements;

namespace CodeFramework.Editor
{
    public class CreateTemplateWindow : CustomEditorWindow<string>
    {
        private TextField entityNameField;
        private Button createEntityButton;
        private string EntityType { get; }

        public CreateTemplateWindow(string entityType)
        {
            EntityType = entityType;
        }

        public override string Result1 => entityNameField.value;

        private void CreateGUI()
        {
            VisualElement root = rootVisualElement;

            Label label = new Label($"Create {EntityType} Window");
            root.Add(label);
            
            
            
            entityNameField = new TextField();
            entityNameField.name = "input field";
            entityNameField.tooltip = $"Enter {EntityType} name...";
            root.Add(entityNameField);
            
            // Create button
            createEntityButton = new Button();
            createEntityButton.clicked += OnClicked;
            createEntityButton.name = "button";
            createEntityButton.text = $"Create {EntityType}";
            root.Add(createEntityButton);

            
        }

        private void OnDestroy()
        {
            createEntityButton.clicked -= OnClicked;
        }

        private void OnClicked()
        {
            var value = entityNameField.value;
            if (!string.IsNullOrEmpty(value))
            {
                InvokeClosedEvent();
            }
        }
    }
}