import { Navigate, Route, Routes } from "react-router-dom";
import { ContactDetailsPage, ContactListPage, NewContactPage, EditContactPage } from '../pages';
import { ContactList } from "../components";

export const ContactsRoutes = () => {
  return (
    <>
      <div className="row">
        <div className="col-3">
          <ContactList />
        </div>

        <div className="col-7">              
          <Routes>
            <Route path="contacts" element={<ContactListPage/>}></Route>
            <Route path="contacts/:id" element={<ContactDetailsPage/>}></Route>
            <Route path="contacts/:id/edit" element={<EditContactPage/>}></Route>
            <Route path="contacts/new" element={<NewContactPage/>}></Route>
            
            <Route path="/" element={<Navigate to="/contacts" />}></Route>
          </Routes>
        </div>
      </div>
    </>
  )
}
