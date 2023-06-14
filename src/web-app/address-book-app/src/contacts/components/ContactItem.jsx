import { NavLink } from "react-router-dom";

export const ContactItem = ({
    id,
    firstName,
    lastName,
    phoneNumber,
    queryParameter
}) => {
    let fullName = `${firstName} ${lastName}`;

    return (
        <>
            <NavLink to={`/contacts/${id}?search=${queryParameter??''}`} className={`list-group-item`} >
                <span>{fullName}</span><br></br>
                <span className="fw-lighter fs-6">{phoneNumber}</span>
            </NavLink>
        </>
    )
  }
  