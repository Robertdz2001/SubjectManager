import React from "react";
import { useNavigate } from "react-router";
import "./HomePage.css";

function HomePage(props) {
    const navigate = useNavigate();

    return (
        <div className="home">
            <div className="nav-bar">
                <div className="nav-subjects" onClick={() => { navigate("/subjects") }}>
                    Subjects
                </div>


                <div className="nav-tests" onClick={() => { navigate("/tests") }}>
                    Tests
                </div>

            </div>


        </div>
    );

}
export default HomePage;