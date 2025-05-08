// wizard.js - Funcionalidad para el asistente de creación de compañía

let currentStep = 0;
const totalSteps = 5;

// Al cargar la página, asegúrate de que solo el primer paso sea visible
document.addEventListener('DOMContentLoaded', function () {
    updateWizardVisibility();
});

// Agregar event listeners a los botones de navegación
function initWizardNavigation() {
    document.getElementById('nextStep').addEventListener('click', function () {
        if (currentStep < totalSteps - 1) {
            currentStep++;
            updateWizard();
        }
    });

    document.getElementById('prevStep').addEventListener('click', function () {
        if (currentStep > 0) {
            currentStep--;
            updateWizard();
        }
    });
}

function updateWizard() {
    // Ya no deshabilitamos el botón de anterior
    // document.getElementById('prevStep').disabled = (currentStep === 0);

    if (currentStep === totalSteps - 1) {
        document.getElementById('nextStep').innerHTML = 'Finalizar<i class="fas fa-check ms-2"></i>';
    } else {
        document.getElementById('nextStep').innerHTML = 'Siguiente<i class="fas fa-arrow-right ms-2"></i>';
    }

    // Actualizar indicadores de paso
    document.querySelectorAll('.step').forEach((step, index) => {
        if (index === currentStep) {
            step.classList.add('active');
        } else {
            step.classList.remove('active');
        }
    });

    // Actualizar visibilidad de los pasos
    updateWizardVisibility();

    // Inicializar cualquier funcionalidad específica del paso
    initCurrentStepFunctionality();
}

function updateWizardVisibility() {
    // Ocultar todos los pasos
    document.querySelectorAll('.wizard-step').forEach(step => {
        step.classList.remove('active');
        step.style.display = 'none';
    });

    // Mostrar solo el paso actual
    const currentStepElement = document.getElementById(`step-${currentStep}`);
    if (currentStepElement) {
        currentStepElement.classList.add('active');
        currentStepElement.style.display = 'block';
    }
}

function initCurrentStepFunctionality() {
    // Inicializar funcionalidades específicas según el paso actual
    switch (currentStep) {
        case 1: // _GeneralData
            initGeneralDataStep();
            break;
        case 2: // _Employees
            // Inicializar funcionalidad específica para empleados
            break;
        case 3: // _Banks
            // Inicializar funcionalidad específica para bancos
            break;
        case 4: // _Confirmation
            // Inicializar funcionalidad específica para confirmación
            break;
    }
}

function initGeneralDataStep() {
    // Inicializar el toggle switch para construcción
    const toggleSwitch = document.getElementById("toggleSwitch");
    if (toggleSwitch) {
        toggleSwitch.addEventListener("change", function () {
            // Ya no cambiamos el estado disabled de los botones de construcción
            // En su lugar, podemos usar clases para cambiar su apariencia
            document.querySelectorAll(".construction-button").forEach(button => {
                if (this.checked) {
                    button.classList.add('active-construction');
                    // button.disabled = !this.checked; <- Eliminado
                } else {
                    button.classList.remove('active-construction');
                    // button.disabled = !this.checked; <- Eliminado
                }
            });
        });
    }
}

// Inicializar la navegación al cargar la página
document.addEventListener('DOMContentLoaded', initWizardNavigation);