package com.alvin.d2_modul2.model

import android.os.Parcel
import android.os.Parcelable

data class Job(
    val id: Int,
    val name: String,
    val companyName: String,
    val locationRegion: String,
    val locationType: String,
    val yearOfExperience: String,
    val quota: Int,
): Parcelable {
    constructor(parcel: Parcel) : this(
        parcel.readInt(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readString().toString(),
        parcel.readInt()
    ) {
    }

    override fun writeToParcel(parcel: Parcel, flags: Int) {
        parcel.writeInt(id)
        parcel.writeString(name)
        parcel.writeString(companyName)
        parcel.writeString(locationType)
        parcel.writeString(locationRegion)
        parcel.writeString(yearOfExperience)
        parcel.writeInt(quota)
    }

    override fun describeContents(): Int {
        return 0
    }

    companion object CREATOR : Parcelable.Creator<Job> {
        override fun createFromParcel(parcel: Parcel): Job {
            return Job(parcel)
        }

        override fun newArray(size: Int): Array<Job?> {
            return arrayOfNulls(size)
        }
    }
}
