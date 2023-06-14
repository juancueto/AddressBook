import { deleteContact, getContactById } from '../helpers/addressbook.service';
import { useEffect, useState } from "react";
import { NavLink, useNavigate, useParams, useSearchParams } from "react-router-dom"

import { format } from 'date-fns';

export const ContactDetailsPage = () => {
  const [ searchParams, setSearchParams ] = useSearchParams();

  const contactSearch = searchParams.get('search');

  const {id} = useParams();
  const navigate = useNavigate();

  const [contact, setContact] = useState(null);

  useEffect(() => {
    const fetchContacts = async() => {
      const response = await getContactById(id);
      
      setContact(response);
    };

    fetchContacts();
  }, [id]);

  const onDeleteContact = () => {
    if(confirm(`are you sure to delete the contact?`)){
      deleteContact(id)
      .then((response) => {
        alert('The contact was deleted');
        navigate(`/contacts?search=`);
      });
    }
  };

  if(!contact)
    return null;

  return (
    <>
      <div className="row">
      {/* animate__animated animate__fadeInLeft */}
        <div className="col-8">
          <div className="card shadow">
            <div className="card-body">
              <h3>{contact.firstName} {contact.lastName}</h3>

              <hr/>

              <ul className="list-group list-group-flush">
                <li className="list-group-item"><b>Phone number:</b> {contact.phoneNumber}</li>
                <li className="list-group-item">
                  <b>Address:</b> {contact.physicalAddress}
                </li>
                <li className="list-group-item"><b>Birthday:</b> {contact.birthday? format(new Date(contact.birthday), 'M/d/yyyy') : ''}</li>
                <li className="list-group-item"><b>Email:</b> {contact.email}</li>
                <li className="list-group-item"><b>Company:</b> {contact.companyName}</li>
              </ul>

              <hr/>

              <div className="row">
                <div className="col-auto">

                  <NavLink className="btn btn-outline-primary" to={`/contacts/${id}/edit?search=${contactSearch}`} >
                    Edit
                  </NavLink>
                </div>
                <div className="col-auto">

                  <button className="btn btn-primary"
                    onClick={onDeleteContact}
                  >
                    Delete
                  </button>
                </div>
              </div>

            </div>
          </div>
        </div>
      </div>
    </>
  )
}
