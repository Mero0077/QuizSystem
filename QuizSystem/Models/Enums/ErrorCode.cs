namespace QuizSystem.Models.Enums
{
    public enum ErrorCode
    {
        NoError=0,

        #region Course
        CourseNotFound = 100,
        InvalidCourseName = 101,
        CourseExists = 102,
        #endregion


        #region Instructor
        InstructorNotFound = 200,
        InvalidInstructorName = 201,
        InstructorExists = 202, 
        #endregion

        ChoiceNotFound=300
    }
}
