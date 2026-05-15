    const Spinner = ({text} : {text: string}) => {

        return(
            <div className="spinner-container">
                <div className="loading-spinner"></div>
                <p>{text}</p>
            </div>
        );
    }

    export default Spinner;