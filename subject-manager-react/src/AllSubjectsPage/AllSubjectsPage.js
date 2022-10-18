import React, { useState } from "react";
import { useNavigate } from "react-router";
import { useEffect } from "react";
import "./AllSubjectsPage.css";
import axios from "axios";
import AllSubjectsList from "./AllSubjectsList/AllSubjectsList";
import SearchBar from "./SearchBar/SearchBar";
import { PlusCircle } from 'react-bootstrap-icons';
import Button from 'react-bootstrap/Button';
const getAllSubjects = async () => {
    const res = await axios.get(
        `https://localhost:7158/api/subjects`,
        {
            headers: {
                'Authorization': localStorage.getItem("token")
            }
        }
    );

    return res.data;
}





function AllSubjectsPage(props) {
    const navigate = useNavigate();
    const [allSubjects, setAllSubjects] = useState(false);
    const [showedSubjects, setShowedSubjects] = useState(false);

    useEffect(() => {
        async function getAll() {

            const all = await getAllSubjects();
            setAllSubjects(all);
            setShowedSubjects(all);
        }
        getAll()

    }, []);

    const changeShowedSubjects = (searchedSubjects) => {
        setShowedSubjects(searchedSubjects);
    }

    if (!showedSubjects) return <div>Loading...</div>;

    return (
        <div className="all-page">


            <div className="all-searchbar">
                <SearchBar changeShowedSubjects={changeShowedSubjects} allSubjects={allSubjects} />
            </div>
            <div className="new-button">
                <Button variant="success" size="lg" onClick={() => { navigate("/subjects/add") }}><PlusCircle />New</Button>
            </div>
            <div className="all-list">
                <AllSubjectsList showedSubjects={showedSubjects} />
            </div>
        </div>
    );

}

export default AllSubjectsPage;