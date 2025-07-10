function createHighlightManager() {
    let hover = [];
    let enabled = false;
    const BORDER_COLOR = '#ff0000';  // Single color constant for both states
 
    function initializeBorders() {
        const borders = ['top', 'right', 'bottom', 'left'];
        borders.forEach(position => {
            const border = document.createElement('div');
            border.className = `highlight-border ${position}`;
            border.style.position = 'absolute';
            border.style.backgroundColor = BORDER_COLOR;  // Use constant color
            border.style.display = 'none';
            border.style.pointerEvents = 'none';
           
            document.body.appendChild(border);
            hover.push(border);
        });
    }
 
    function calculateBorderPositions(element, padding = 2) {
        const rect = element.getBoundingClientRect();
        const scrollLeft = window.pageXOffset || document.documentElement.scrollLeft;
        const scrollTop = window.pageYOffset || document.documentElement.scrollTop;
        const borderWidth = 2;
       
        return {
            top: {
                left: scrollLeft + rect.left - padding + 'px',
                top: scrollTop + rect.top - padding + 'px',
                width: rect.width + (padding * 2) + 'px',
                height: borderWidth + 'px'
            },
            right: {
                left: scrollLeft + rect.right + padding - borderWidth + 'px',
                top: scrollTop + rect.top - padding + 'px',
                width: borderWidth + 'px',
                height: rect.height + (padding * 2) + 'px'
            },
            bottom: {
                left: scrollLeft + rect.left - padding + 'px',
                top: scrollTop + rect.bottom + padding - borderWidth + 'px',
                width: rect.width + (padding * 2) + 'px',
                height: borderWidth + 'px'
            },
            left: {
                left: scrollLeft + rect.left - padding + 'px',
                top: scrollTop + rect.top - padding + 'px',
                width: borderWidth + 'px',
                height: rect.height + (padding * 2) + 'px'
            }
        };
    }
 
    function highlightElement2(element) {
        if (!enabled) return;
 
        // Hide any existing highlight first
        hideHighlight();
 
        // Calculate and apply new highlight
        const positions = calculateBorderPositions(element);
        const borders = ['top', 'right', 'bottom', 'left'];
       
        borders.forEach((position, index) => {
            const borderStyle = hover[index].style;
            borderStyle.display = 'block';
            borderStyle.left = positions[position].left;
            borderStyle.top = positions[position].top;
            borderStyle.width = positions[position].width;
            borderStyle.height = positions[position].height;
            borderStyle.backgroundColor = BORDER_COLOR;  // Ensure color is set consistently
        });
    }
 
    function hideHighlight() {
        hover.forEach(border => {
            border.style.display = 'none';
        });
    }
 
    function generateUniqueId() {
        return 'id-' + Math.random().toString(36).substr(2, 16);
    }
 
    function mouseoverHandler(e) {
        if (!enabled || e.target.hasAttribute('data-unique-id')) return;
        highlightElement2(e.target);
    }
 
    function mouseoutHandler() {
        if (!document.querySelector('[data-unique-id]')) {
            hideHighlight();
        }
    }
 
    function clickHandler(e) {
        if (!enabled) return;
        const element = e.target;
 
        // If element is already highlighted, remove highlight and return
        if (element.hasAttribute('data-unique-id')) {
            element.removeAttribute('data-unique-id');
            hideHighlight();
            return;
        }
        hideHighlight();
        // Add new highlight
        element.setAttribute('data-unique-id', generateUniqueId());
        highlightElement2(element);
    }
 
    function bindEvents() {
        document.addEventListener('mouseover', mouseoverHandler);
        document.addEventListener('mouseout', mouseoutHandler);
        document.addEventListener('click', clickHandler);
    }
 
    function toggle(isEnabled) {
        enabled = isEnabled;
        if (!isEnabled) {
            hideHighlight();
            const highlightedElement = document.querySelector('[data-unique-id]');
            if (highlightedElement) {
                highlightedElement.removeAttribute('data-unique-id');
            }
        } else {
            initializeBorders();
            bindEvents();
        }
    }
 
    return {
        toggle,
        hideHighlight
    };
}
 
// Add CSS
const style = document.createElement('style');
style.textContent = `
    .highlight-border {
        position: absolute;
        z-index: 10000;
        pointer-events: none;
    }
    .highlight-border.top,
    .highlight-border.bottom {
        height: 2px;
    }
    .highlight-border.left,
    .highlight-border.right {
        width: 2px;
    }
`;
document.head.appendChild(style);
 
// Usage:
const highlighter = createHighlightManager();